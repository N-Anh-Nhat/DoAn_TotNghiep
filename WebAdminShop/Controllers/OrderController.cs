using LIB.BaseModels;
using LIB.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAdminShop.ApiCaller;
using WebAPI.Models;

namespace WebAdminShop.Controllers
{
    public class OrderController : Controller
    {

        private IOptionsSnapshot<MySettingsModel> appSettings;
        private IOptionsSnapshot<AuthenInfo> authenSettings;
        private readonly UserInfo userInfo;
        public OrderController(IOptionsSnapshot<MySettingsModel> app, IOptionsSnapshot<AuthenInfo> authen)
        {

            appSettings = app;
            authenSettings = authen;
            ApplicationSettings.WebApiUrl = app.Value.WebApiBaseUrl;
            userInfo = new UserInfo();
        }
        public async Task<IActionResult> Index()
        {
            string json = userInfo.GetUserInfo(HttpContext);

            if (json != null)
            {
                var res = await ApiClientFactory.Instance.GetProduct("");
                ViewBag.listproduct = res;
                var res2 = await ApiClientFactory.Instance.GetProductSize("");
                ViewBag.listsize = res2;
                return View();
            }
            return RedirectToAction("Index", "Login");
        }
       

        [HttpGet]
        public async Task<IActionResult> GetlstOrder()
        {
            string json = userInfo.GetUserInfo(HttpContext);

            if (json != null)
            {
                var Token = await ApiClientFactory.Instance.GetTokenAsync();
                var res = await ApiClientFactory.Instance.GetOrder(Token);
                List<Orders> data = new List<Orders>();
                foreach(var item in res)
                {
                    if (item.ID_TrangThaiDonHang == 1)
                        data.Add(item);
                }
                return Json(data);
            }
            return RedirectToAction("Index", "Login");
        }

       
        [HttpGet]
        public async Task<IActionResult> GetlstOrderDetail(int id)
        {
            string json = userInfo.GetUserInfo(HttpContext);

            if (json != null)
            {
                var Token = await ApiClientFactory.Instance.GetTokenAsync();
                var res = await ApiClientFactory.Instance.GetOrder_detailById(id,Token);
               
                return Json(res);
            }
            return RedirectToAction("Index", "Login");
        }
        [HttpPost]
        public async Task<IActionResult> InsertlstOrder([FromBody] Orders data)
        {
            //string json = userInfo.GetUserInfo(HttpContext);

            //if (json != null)
            //{
            //UserInfoModel curUser = JsonConvert.DeserializeObject<UserInfoModel>(json);

            //curUser.token = await ApiClientFactory.Instance.RefeshToken(curUser);
            var Token = await ApiClientFactory.Instance.GetTokenAsync();
            var res = await ApiClientFactory.Instance.InsertOrder(data, "", Token);

            return Json(res);
            ////}
            //return null;
        }

        [HttpPost]
        public async Task<IActionResult> UpdatelstOrder([FromBody] Orders data,int TrangThai)
        {
            string json = userInfo.GetUserInfo(HttpContext);

            if (json != null)
            {

                var Token = await ApiClientFactory.Instance.GetTokenAsync();
                var user = await ApiClientFactory.Instance.GetUserById(data.ID_User,Token);
              
                data.Status = true;
              
                if (TrangThai == 4)
                {
                    var OderDetail = await ApiClientFactory.Instance.GetOrder_detailById(data.ID,Token);
                    List<ProductSize> updatelist = new List<ProductSize>();
                    var listProductSize = await ApiClientFactory.Instance.GetProductSize(Token);
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
                    var resUpdate = await ApiClientFactory.Instance.UpdatelstProductSize(updatelist, "", Token);
                    if (resUpdate.Data.Status == 1)
                    {
                        var res = await ApiClientFactory.Instance.UpdateOrder(data, TrangThai, "", Token);
                        MailContent content = new MailContent
                        {
                            To = user.Email,
                            Subject = "Hủy đơn hàng",
                            Body = "<p><strong>Đơn "+ data.Name_order + " hàng của bạn đã bị hủy </strong></p>" + "<p>Vui lòng liên hệ Admin SDT 0365742833 để biết thêm chi tiết.</p>"
                        };
                        var send = await ApiClientFactory.Instance.SendMail(content,Token);

                        return Json(res);
                    }
                    else
                        return Json(resUpdate);
                }
                else if(TrangThai == 2)
                {
                    MailContent content = new MailContent
                    {
                        To = user.Email,
                        Subject = "Duyệt đơn hàng",
                        Body = "<p><strong>Đơn " + data.Name_order + " hàng của bạn đã được duyệt </strong></p>" + "<p>Hàng sẽ được giao đến trong vài ngày tới. Vui lòng liên hệ Admin SDT 0365742833 để biết thêm chi tiết.</p>"
                    };
                    var send = await ApiClientFactory.Instance.SendMail(content, Token);
                    var res = await ApiClientFactory.Instance.UpdateOrder(data, TrangThai, "", Token);
                    return Json(res);
                }
                else if(TrangThai == 3)
                {
                    MailContent content = new MailContent
                    {
                        To = user.Email,
                        Subject = "Thanh toán thành công",
                        Body = "<p><strong>Đơn " + data.Name_order + " hàng của bạn đã được thanh toán thành công </strong></p>" + "<p>Cảm ơn bạn đã ủng hộ shop!. Vui lòng liên hệ Admin SDT 0365742833 để biết thêm chi tiết.</p>"
                    };
                    var send = await ApiClientFactory.Instance.SendMail(content, Token);
                    var res = await ApiClientFactory.Instance.UpdateOrder(data, TrangThai, "", Token);
                    return Json(res);
                }
            }
            return RedirectToAction("Index", "Login");
        }
        
    }
}
