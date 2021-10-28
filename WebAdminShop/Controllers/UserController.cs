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
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> GetlstUser()
        {

            var res = await ApiClientFactory.Instance.GetUser("");

            return Json(res);
        }

        [HttpPost]
        public async Task<IActionResult> InsertlstUser([FromBody] User data)
        {
            //string json = userInfo.GetUserInfo(HttpContext);

            //if (json != null)
            //{
            //UserInfoModel curUser = JsonConvert.DeserializeObject<UserInfoModel>(json);

            //curUser.token = await ApiClientFactory.Instance.RefeshToken(curUser);

            var res = await ApiClientFactory.Instance.InsertUser(data, "", "");

            return Json(res);
            ////}
            //return null;
        }

        [HttpPost]
        public async Task<IActionResult> UpdatelstUser([FromBody] User data, [FromQuery] string value)
        {
            //string json = userInfo.GetUserInfo(HttpContext);
            JsonConvert.PopulateObject(value, data);
            //if (json != null)
            //{
            //    UserInfoModel curUser = JsonConvert.DeserializeObject<UserInfoModel>(json);

            //    curUser.token = await ApiClientFactory.Instance.RefeshToken(curUser);

            var res = await ApiClientFactory.Instance.UpdateUser(data, "", "");

            return Json(res);

            //}
            //return null;
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
