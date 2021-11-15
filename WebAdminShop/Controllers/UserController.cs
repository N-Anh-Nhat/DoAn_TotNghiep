using LIB.BaseModels;
using LIB.Common;
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
using Newtonsoft.Json;

namespace WebAdminShop.Controllers
{
    public class UserController : Controller
    {

        private IOptionsSnapshot<MySettingsModel> appSettings;
        private IOptionsSnapshot<AuthenInfo> authenSettings;
        private readonly UserInfo userInfo;
        public UserController(IOptionsSnapshot<MySettingsModel> app, IOptionsSnapshot<AuthenInfo> authen)
        {

            appSettings = app;
            authenSettings = authen;
            ApplicationSettings.WebApiUrl = app.Value.WebApiBaseUrl;
            userInfo = new UserInfo();
        }
        public IActionResult Index()
        {
            string json = userInfo.GetUserInfo(HttpContext);

            if (json != null)
            {
                return View();
            }
            return RedirectToAction("Index", "Login");
        }


        [HttpGet]
        public async Task<IActionResult> GetlstUser()
        {
            string json = userInfo.GetUserInfo(HttpContext);

            if (json != null)
            {
                var Token = await ApiClientFactory.Instance.GetTokenAsync();
                var res = await ApiClientFactory.Instance.GetUser(Token);

                return Json(res);
            }
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public async Task<IActionResult> InsertlstUser([FromBody] User data)
        {
            string json = userInfo.GetUserInfo(HttpContext);

            if (json != null)
            {
                //UserInfoModel curUser = JsonConvert.DeserializeObject<UserInfoModel>(json);

                //curUser.token = await ApiClientFactory.Instance.RefeshToken(curUser);
                var Token = await ApiClientFactory.Instance.GetTokenAsync();
                var res = await ApiClientFactory.Instance.InsertUser(data, "", Token);

                return Json(res);

            }

            return RedirectToAction("Index", "Login");
        }
        [HttpPost]
        public async Task<IActionResult> UpdatelstUser([FromBody] User data, [FromQuery] string value)
        {
            string json = userInfo.GetUserInfo(HttpContext);
            JsonConvert.PopulateObject(value, data);
            if (json != null)
            {
                var Token = await ApiClientFactory.Instance.GetTokenAsync();
                //    UserInfoModel curUser = JsonConvert.DeserializeObject<UserInfoModel>(json);

                //    curUser.token = await ApiClientFactory.Instance.RefeshToken(curUser);

                var res = await ApiClientFactory.Instance.UpdateUser(data, "", Token);

                return Json(res);

            }
            return RedirectToAction("Index", "Login");
        }
        //[HttpDelete]
        //public async Task<IActionResult> DeletelstUser(string id)
        //{
        //    string json = userInfo.GetUserInfo(HttpContext);

        //    if (json != null)
        //    {
        //        UserInfoModel curUser = JsonConvert.DeserializeObject<UserInfoModel>(json);

        //        curUser.token = await ApiClientFactory.Instance.RefeshToken(curUser);

        //        var res = await ApiClientFactory.Instance.DeletelstUser(id, curUser.token);

        //        return Json(res);
        //    }

        //    return null;
        //}
    }
}
