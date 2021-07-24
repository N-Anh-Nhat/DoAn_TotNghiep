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
    public class ADSController : Controller
    {

        private IOptionsSnapshot<MySettingsModel> appSettings;
        private IOptionsSnapshot<AuthenInfo> authenSettings;
        private readonly UserInfo userInfo;
        public ADSController(IOptionsSnapshot<MySettingsModel> app, IOptionsSnapshot<AuthenInfo> authen)
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
        public async Task<IActionResult> GetlstADS()
        {

            var res = await ApiClientFactory.Instance.GetADS("");

            return Json(res);
        }

        [HttpPost]
        public async Task<IActionResult> InsertlstADS([FromBody] ADS data)
        {
            //string json = userInfo.GetUserInfo(HttpContext);

            //if (json != null)
            //{
            //UserInfoModel curUser = JsonConvert.DeserializeObject<UserInfoModel>(json);

            //curUser.token = await ApiClientFactory.Instance.RefeshToken(curUser);

            var res = await ApiClientFactory.Instance.InsertADS(data, "", "");

            return Json(res);
            ////}
            //return null;
        }

        [HttpPost]
        public async Task<IActionResult> UpdatelstADS([FromBody] ADS data, [FromQuery] string value)
        {
            //string json = userInfo.GetUserInfo(HttpContext);
            JsonConvert.PopulateObject(value, data);
            //if (json != null)
            //{
            //    UserInfoModel curUser = JsonConvert.DeserializeObject<UserInfoModel>(json);

            //    curUser.token = await ApiClientFactory.Instance.RefeshToken(curUser);

            var res = await ApiClientFactory.Instance.UpdateADS(data, "", "");

            return Json(res);

            //}
            //return null;
        }
        //[HttpDelete]
        //public async Task<IActionResult> DeletelstADS(string id)
        //{
        //    string json = userInfo.GetUserInfo(HttpContext);

        //    if (json != null)
        //    {
        //        UserInfoModel curUser = JsonConvert.DeserializeObject<UserInfoModel>(json);

        //        curUser.token = await ApiClientFactory.Instance.RefeshToken(curUser);

        //        var res = await ApiClientFactory.Instance.DeletelstADS(id, curUser.token);

        //        return Json(res);
        //    }

        //    return null;
        //}
    }
}
