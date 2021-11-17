using LIB.BaseModels;
using LIB.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUserShop.ApiCaller;
using WebAPI.Models;
using LIB.Base;
using Microsoft.AspNetCore.Hosting;

using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace WebUserShop.Controllers
{
    public class UserController : Controller
    {
        private IOptionsSnapshot<MySettingsModel> appSettings;
        private IOptionsSnapshot<AuthenInfo> authenSettings;
        private readonly UserInfo userInfo;
        private readonly IWebHostEnvironment _env;
        public UserController(IOptionsSnapshot<MySettingsModel> app, IOptionsSnapshot<AuthenInfo> authen, IWebHostEnvironment env)
        {

            appSettings = app;
            authenSettings = authen;
            ApplicationSettings.WebApiUrl = app.Value.WebApiBaseUrl;
            userInfo = new UserInfo();
            _env = env;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> ChiTietDonHang(int id)
        {
            if (HttpContext.Session.GetString("user1") != null)
            {
                var Token = await ApiClientFactory.Instance.GetTokenAsync();
                var rsPro = await ApiClientFactory.Instance.GetProduct(Token);
                var rsSize = await ApiClientFactory.Instance.GetProductSize(Token);
                ViewBag.Product = rsPro;
                ViewBag.Size = rsSize;
                var res = await ApiClientFactory.Instance.GetOrder_detailById(id,Token);
                ViewBag.listorder = res;    
                return PartialView();
            }
            else
            {
                 return NotFound();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] User user)
        {
            var Token = await ApiClientFactory.Instance.GetTokenAsync();
            user.Status = true;
            user.ID_Role = 2;
            var KQ = await ApiClientFactory.Instance.InsertUser(user, "", Token);
            return Json(KQ);


        }

        public IActionResult LoginIndex()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(string tkLogin, string mkLogin)
         {
            var Token = await ApiClientFactory.Instance.GetTokenAsync();
            var x = false;
            var res = await ApiClientFactory.Instance.GetUser(Token);
            var c_pass = Security.TextToMD5(mkLogin);
            var data = res.Where(u => u.UserName.Equals(tkLogin) && u.Password.Equals(c_pass) && u.ID_Role == 2&& u.Status==true).FirstOrDefault<User>(); ;
            var dataAdmin = res.Where(u => u.UserName.Equals(tkLogin) && u.Password.Equals(c_pass) && u.ID_Role == 1 && u.Status == true).FirstOrDefault<User>(); ;
            if (data != null)
            {
                var str = JsonConvert.SerializeObject(data);
                HttpContext.Session.SetString("user1", str);
                HttpContext.Session.SetString("userHello", tkLogin);
                x = true;
                return Json(x);
            }
            if (dataAdmin != null)
            {
                var str = JsonConvert.SerializeObject(data);
                HttpContext.Session.SetString("userAdmin", str);
                HttpContext.Session.SetString("userHelloAdmin", tkLogin);
                x = true;
                return Json(x);
            }
            else
            {
                x = false;
                return Json(x);
            }
            
        }
        [HttpGet]
        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("user1") != null)
            {
                HttpContext.Session.Remove("user1");
                HttpContext.Session.Remove("userHello");
            }
            if (HttpContext.Session.GetString("Cart_Key") != null)
            {
                HttpContext.Session.Remove("Cart_Key");

            }
            if (HttpContext.Session.GetString("userAdmin") != null)
            {
                HttpContext.Session.Remove("userAdmin");
                HttpContext.Session.Remove("userHelloAdmin");
                return RedirectToAction("Index", "TheWayShop");
            }
            return RedirectToAction("Index", "TheWayShop");
        }

        [HttpGet]
        public async Task<IActionResult> GetlstUser(string User)
        {
            var Token = await ApiClientFactory.Instance.GetTokenAsync();
            var res = await ApiClientFactory.Instance.GetUser(Token);
            //kiem tra trung user
            var UserCount = res.Where(u => u.UserName.Equals(User)).Select(x => x.ID).Count();
            bool result=UserCount > 0 ? false : true;
            return Json(result);
        }
        [HttpGet]
        public IActionResult UniquePass(string Pass)
        {
            if (HttpContext.Session.GetString("user1") != null)
            {


                bool result = true;
                string b = HttpContext.Session.GetString("user1");
                var user = JsonConvert.DeserializeObject<User>(b);
                var c_pass = Security.TextToMD5(Pass);
                //kiem tra trung user
                var UserCount = user.Password.Equals(c_pass);
                if (UserCount == true)
                {
                    result = true;
                    return Json(result);
                }
                else
                {
                    result = false;
                    return Json(result);
                }

            }
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetlstUserofMail(string mail)
        {
            var Token = await ApiClientFactory.Instance.GetTokenAsync();
            var resMail = await ApiClientFactory.Instance.GetUser(Token);
            //kiem tra trung mail
            var mailCount = resMail.Where(u => u.Email.Equals(mail)).Select(x => x.ID).Count();
            bool result = mailCount > 0 ? false : true;
            return Json(result);
        }

        public async Task<IActionResult> ĐonHang()
        {
           if (HttpContext.Session.GetString("user1") != null)
            {
                var Token = await ApiClientFactory.Instance.GetTokenAsync();
                string b = HttpContext.Session.GetString("user1");
                var user = JsonConvert.DeserializeObject<User>(b);

                var res = await ApiClientFactory.Instance.GetOrder(Token);
                


                //danh sách đơn hàng
                var ListOrder= res.Where(s => s.ID_User == user.ID).ToList();
               
                ViewBag.ListOrder = ListOrder.OrderByDescending(s=>s.ID);
                return View();
            }
            else
            {
                return NotFound();
            }
            
        }
        [HttpPost]
        public async Task<IActionResult> InsertWishList([FromBody] WishList data)
        {
            if (HttpContext.Session.GetString("user1") != null)
            {
                var Token = await ApiClientFactory.Instance.GetTokenAsync();
                string a = HttpContext.Session.GetString("user1");
                var user = JsonConvert.DeserializeObject<User>(a);
                var wl = await ApiClientFactory.Instance.GetWishList(Token);
                var listSpWishList = wl.Where(s => s.ID_User == user.ID).ToList();
                foreach (var item in listSpWishList)
                {
                    if (item.ID_Product==data.ID_Product)
                    {
                        return Json(false);
                    }
                }
                data.ID_User = user.ID;
                var res = await ApiClientFactory.Instance.InsertWishList(data, user.UserName, Token);
                return Json(true);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public async Task<IActionResult> DeleteWishList([FromBody] WishList data)
        {
            if (HttpContext.Session.GetString("user1") != null)
            {
                var Token = await ApiClientFactory.Instance.GetTokenAsync();
                var wl = await ApiClientFactory.Instance.DeleteWishList(data,"",Token);
                return Json(true);
            }
            else
            {
                return NotFound();
            }

        }
        [HttpPost]
        public async Task<IActionResult> InsertMessage([FromBody] CMT data)
        {
            if (HttpContext.Session.GetString("user1") != null)
            {
                var Token = await ApiClientFactory.Instance.GetTokenAsync();
                string a = HttpContext.Session.GetString("user1");
                var user = JsonConvert.DeserializeObject<User>(a);
                data.ID_User = user.ID;
                var insertCmt = await ApiClientFactory.Instance.InsertCMT(data, user.UserName, Token);
                return Json(true);
            }
            else 
            {
                return NotFound();
            }
        }
        public async Task<IActionResult> DeleteMessage([FromBody] CMT data)
        {
            if (HttpContext.Session.GetString("userAdmin") != null)
            {
                var Token = await ApiClientFactory.Instance.GetTokenAsync();
                var deleCmt = await ApiClientFactory.Instance.DeleteCMT(data, "", Token);
                return Json(true);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
