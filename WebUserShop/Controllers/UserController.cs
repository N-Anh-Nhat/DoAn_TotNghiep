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
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] User user)
        {
            user.Status = true;
            user.ID_Role = 2;
            var KQ = await ApiClientFactory.Instance.InsertUser(user, "", "");
            return Json(KQ);


        }

        public IActionResult LoginIndex()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(string tkLogin, string mkLogin)
         {
            var x = false;
            var res = await ApiClientFactory.Instance.GetUser("");
            var c_pass = Security.TextToMD5(mkLogin);
            var data = res.Where(u => u.UserName.Equals(tkLogin) && u.Password.Equals(c_pass) && u.ID_Role == 2).FirstOrDefault<User>(); ;
            if (data != null)
            {
                var str = JsonConvert.SerializeObject(data);
                HttpContext.Session.SetString("user1", str);
                HttpContext.Session.SetString("userHello", tkLogin);
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
            HttpContext.Session.Remove("user1");
            HttpContext.Session.Remove("userHello");
            return RedirectToAction("Index", "TheWayShop");
        }

        [HttpGet]
        public async Task<IActionResult> GetlstUser(string User)
        {

            var res = await ApiClientFactory.Instance.GetUser("");
            //kiem tra trung user
            var UserCount = res.Where(u => u.UserName.Equals(User)).Select(x => x.ID).Count();
            bool result=UserCount > 0 ? false : true;
            return Json(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetlstUserofMail(string mail)
        {

            var resMail = await ApiClientFactory.Instance.GetUser("");
            //kiem tra trung user
            var mailCount = resMail.Where(u => u.Email.Equals(mail)).Select(x => x.ID).Count();
            bool result = mailCount > 0 ? false : true;
            return Json(result);
        }

    }
}
