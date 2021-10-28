using LIB.Base;
using LIB.BaseModels;
using LIB.Common;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebAdminShop.ApiCaller;
using WebAPI.Models;

namespace WebAdminShop.Controllers
{
    public class LoginController : Controller
    {

        private IOptionsSnapshot<MySettingsModel> appSettings;
        private IOptionsSnapshot<AuthenInfo> authenSettings;
        private readonly UserInfo userInfo;
        private readonly IWebHostEnvironment _env;
        public LoginController(IOptionsSnapshot<MySettingsModel> app, IOptionsSnapshot<AuthenInfo> authen, IWebHostEnvironment env)
        {

            appSettings = app;
            authenSettings = authen;
            ApplicationSettings.WebApiUrl = app.Value.WebApiBaseUrl;
            userInfo = new UserInfo();
            _env = env;
        }
        public IActionResult Index()
        {
            return View("Login", new { username = "", message = "" });
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var rs = await ApiClientFactory.Instance.CheckLogin(username, password);

            if (rs.Status == 1)
            {
                var sessionLogin = HttpContext.Session;

                var obj = new UserInfoModel(rs.Data.UserName, rs.Data, "", "en");

                MemoryCache.AddSection(sessionLogin, obj);

                return RedirectToAction("Index", "Index");
            }

            return View("Login", new { username, message = rs.Message });
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            string json = userInfo.GetUserInfo(HttpContext);

            if (json != null)
            {
                UserInfoModel curUser = JsonConvert.DeserializeObject<UserInfoModel>(json);
                var session = HttpContext.Session;
                MemoryCache.ClearSection(session);
                return View("Login", new { username = curUser.username, message = "See you again ! " + curUser.username });
            }
            return View("Login", new { username = "", message = "" });
        }

    }
}
