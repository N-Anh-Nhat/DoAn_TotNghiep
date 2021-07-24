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

namespace WebAdminShop.Controllers
{
    public class RoleController : Controller
    {

        private IOptionsSnapshot<MySettingsModel> appSettings;
        private IOptionsSnapshot<AuthenInfo> authenSettings;
        private readonly UserInfo userInfo;
        public RoleController(IOptionsSnapshot<MySettingsModel> app, IOptionsSnapshot<AuthenInfo> authen)
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
        public async Task<IActionResult> GetlstRole()
        {

            var res = await ApiClientFactory.Instance.GetRole("");

            return Json(res);
        }

        [HttpPost]
        public async Task<IActionResult> InsertlstRole([FromBody] Role data)
        {
            //string json = userInfo.GetUserInfo(HttpContext);

            //if (json != null)
            //{
            //UserInfoModel curUser = JsonConvert.DeserializeObject<UserInfoModel>(json);

            //curUser.token = await ApiClientFactory.Instance.RefeshToken(curUser);

            var res = await ApiClientFactory.Instance.InsertRole(data, "", "");

            return Json(res);
            ////}
            //return null;
        }

        [HttpPost]
        public async Task<IActionResult> UpdatelstRole([FromBody] Role data, [FromQuery] string value)
        {
            //string json = userInfo.GetUserInfo(HttpContext);
            JsonConvert.PopulateObject(value, data);
            //if (json != null)
            //{
            //    UserInfoModel curUser = JsonConvert.DeserializeObject<UserInfoModel>(json);

            //    curUser.token = await ApiClientFactory.Instance.RefeshToken(curUser);

            var res = await ApiClientFactory.Instance.UpdateRole(data, "", "");

            return Json(res);

            //}
            //return null;
        }
        //[HttpDelete]
        //public async Task<IActionResult> DeletelstRole(string id)
        //{
        //    string json = userInfo.GetUserInfo(HttpContext);

        //    if (json != null)
        //    {
        //        UserInfoModel curUser = JsonConvert.DeserializeObject<UserInfoModel>(json);

        //        curUser.token = await ApiClientFactory.Instance.RefeshToken(curUser);

        //        var res = await ApiClientFactory.Instance.DeletelstRole(id, curUser.token);

        //        return Json(res);
        //    }

        //    return null;
        //}
    }
}
