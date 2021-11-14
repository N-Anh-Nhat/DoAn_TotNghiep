using LIB.BaseModels;
using LIB.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Options;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUserShop.ApiCaller;
using WebAPI.Models;
using X.PagedList;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Data.SqlClient;

namespace WebUserShop.Controllers
{
    public class CartController : Controller
    {
        private IOptionsSnapshot<MySettingsModel> appSettings;
        private IOptionsSnapshot<AuthenInfo> authenSettings;
        private readonly UserInfo userInfo;
        public const string key_cart = "Cart_Key";
        public CartController(IOptionsSnapshot<MySettingsModel> app, IOptionsSnapshot<AuthenInfo> authen)
        {

            appSettings = app;
            authenSettings = authen;
            ApplicationSettings.WebApiUrl = app.Value.WebApiBaseUrl;
            userInfo = new UserInfo();
        }
        public async Task<IActionResult> Cart()
        {
            var rsPro = await ApiClientFactory.Instance.GetProduct("");
            var rsSize = await ApiClientFactory.Instance.GetProductSize("");
            ViewBag.Product = rsPro;
            ViewBag.Size = rsSize;
            return View();
            
            
        }
        [HttpPost]
        public async Task<IActionResult> AddProductToCart(int id, int size)
        {

            try
            {
                var rsPro = await ApiClientFactory.Instance.GetProduct("");
                var rsSize = await ApiClientFactory.Instance.GetProductSize("");
                var Pro = new Product();
                Pro = rsPro.Where(x => x.ID == id).FirstOrDefault();
                var listSize = new ProductSize();
                listSize = rsSize.Where(x => x.ID == size).FirstOrDefault();
                if(listSize.Quality == 0)
                {
                    return Json(4);
                }
                else
                {
                    if (HttpContext.Session.GetString(key_cart) == null)
                    {

                        var listCartItem = new List<Order_Details>();
                        var item = new Order_Details();
                        item.ID_Size = size;
                        item.Price = Pro.Price;
                        item.Quality = 1;
                        item.Note = Pro.Name;
                        item.PromotionPrice = Pro.PromotionPrice;
                        listCartItem.Add(item);
                        SaveCart(listCartItem);
                        return Json(true);
                    }
                    else
                    {
                        var lst = GetCartItem();
                        var ktr = lst.Find(x => x.ID_Size == size);
                        if (ktr != null)
                        {
                            ktr.Quality = ktr.Quality + 1;
                            SaveCart(lst);
                        }
                        else
                        {
                            var item = new Order_Details();

                            item.ID_Size = size;
                            item.Price = Pro.Price;
                            item.Quality = 1;
                            item.Note = Pro.Name;
                            item.PromotionPrice = Pro.PromotionPrice;
                            lst.Add(item);
                            SaveCart(lst);
                        }

                        return Json(true);
                    }
                }
               
            }
           catch(Exception e)
            {
                var mes = e;
                return Json(false);
            }
                 
        }
        [HttpPost]
        public async Task<IActionResult> ClearItemInCart(int id)
        {
            try
            {
                if (HttpContext.Session.GetString(key_cart) != null)
                {
                    var listItem = GetCartItem();
                    var item = listItem.Find(x => x.ID_Size == id);
                    if (item != null)
                        listItem.Remove(item);
                    if(listItem.Count > 0)
                        SaveCart(listItem);
                    if (listItem.Count <= 0)
                        ClearCart();
                    
                }

                    return Json(true);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return Json(false);
            }
        }
        [HttpPost]
        public async Task<IActionResult> UpdateItemInCart(int size, int soluong)
        {
            try
            {
                if (HttpContext.Session.GetString(key_cart) != null)
                {
                    var listItem = GetCartItem();
                    var item = listItem.Find(x => x.ID_Size == size);
                    if (item != null)
                        item.Quality = soluong;
                    SaveCart(listItem);
                }

                return Json(true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Json(false);
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertOrder([FromBody]Orders data)
        {
            if (HttpContext.Session.GetString("user1") != null)
            {
               
                string a = HttpContext.Session.GetString("user1");
                var user = JsonConvert.DeserializeObject<User>(a);
                data.ID_User = user.ID;
                data.Address = data.Address.Trim();
                data.Email = data.Email.Trim();
                data.Phone = data.Phone.Trim();
                data.Note = data.Note.Trim();
                data.Name_order = "Giỏ hàng ngày " + DateTime.Now + "của " + user.UserName;
                var res = await ApiClientFactory.Instance.InsertOrder(data, user.UserName, "");
                return Json(res);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> InsertOrderDetail()
        {
            if (HttpContext.Session.GetString("user1") != null)
            {
                string a = HttpContext.Session.GetString("user1");
                var user = JsonConvert.DeserializeObject<User>(a);
                var data = GetCartItem();

               
                List<ProductSize> updatelist = new List<ProductSize>();
                var listProductSize = await ApiClientFactory.Instance.GetProductSize("");
                foreach(var item in listProductSize)
                {
                    foreach(var rs in data)
                    {
                        if(rs.ID_Size == item.ID)
                        {
                            item.Quality = item.Quality - rs.Quality;
                            updatelist.Add(item);
                        }
                    }
                }
                var resUpdate = await ApiClientFactory.Instance.UpdatelstProductSize(updatelist, "", "");
                if(resUpdate.IsSuccess == true)
                {
                    if (resUpdate.Data.Status == 1)
                    {
                        var res = await ApiClientFactory.Instance.InsertOrder_Detail(data, "", "");
                        if (res.IsSuccess == true)
                            if (res.Data.Status == 1)
                            {
                                ClearCart();
                                MailContent content = new MailContent
                                {
                                    To = user.Email,
                                    Subject = "Đặt hàng thành công",
                                    Body = "<p><strong>Đơn hàng của bạn đã được đặt </strong></p>" + "<p>Cảm ơn bạn đã ủng hộ shop!. Vui lòng liên hệ Admin SDT 0365742833 để biết thêm chi tiết.</p>"
                                };
                                var send = await ApiClientFactory.Instance.SendMail(content, "");
                            }
                                
                        return Json(res);
                    }
                    else
                    {
                        resUpdate.ReturnMessage = "Update số lương thất bại";
                        return Json(resUpdate);
                    }
                }
              
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> UpdatelstOrder([FromBody] Orders data, int TrangThai)
        {
            if (HttpContext.Session.GetString("user1") != null)
            {
                string a = HttpContext.Session.GetString("user1");
                var user = JsonConvert.DeserializeObject<User>(a);

                data.Status = true;

                if (TrangThai == 4)
                {
                    var OderDetail = await ApiClientFactory.Instance.GetOrder_detailById(data.ID, "");
                    List<ProductSize> updatelist = new List<ProductSize>();
                    var listProductSize = await ApiClientFactory.Instance.GetProductSize("");
                    foreach (var item in listProductSize)
                    {
                        foreach (var rs in OderDetail)
                        {
                            if (rs.ID_Size == item.ID)
                            {
                                item.Quality = item.Quality + rs.Quality;
                                updatelist.Add(item);
                            }
                        }
                    }
                    var resUpdate = await ApiClientFactory.Instance.UpdatelstProductSize(updatelist, "", "");
                    if (resUpdate.Data.Status == 1)
                    {
                        var res = await ApiClientFactory.Instance.UpdateOrder(data, TrangThai, "", "");
                        MailContent content = new MailContent
                        {
                            To = user.Email,
                            Subject = "Hủy đặt hàng thành công",
                            Body = "<p><strong>Đơn hàng của bạn đã được hủy </strong></p>" + "<p>Cảm ơn bạn đã ủng hộ shop!. Vui lòng liên hệ Admin SDT 0365742833 để biết thêm chi tiết.</p>"
                        };
                        var send = await ApiClientFactory.Instance.SendMail(content, "");
                        return Json(res);
                    }
                    else
                        return Json(resUpdate);
                }
               
            }
            return RedirectToAction("Index", "Login");
        }

        #region Xử lí cart
        public void SaveCart(List<Order_Details> lst)
        {
            var SessionCart = HttpContext.Session;
            string jsoncart = JsonConvert.SerializeObject(lst);
            SessionCart.SetString(key_cart, jsoncart);
        }
        public List<Order_Details> GetCartItem()
        {
            var session = HttpContext.Session;
            string jsoncart = session.GetString(key_cart);
            if (jsoncart != null)
            {
                return JsonConvert.DeserializeObject<List<Order_Details>>(jsoncart);
            }
            return new List<Order_Details>();
        }
        public void ClearCart()
        {
            var session = HttpContext.Session;
            session.Remove(key_cart);
        }

        #endregion
    }
}
