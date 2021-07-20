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
    public class CategoryController : Controller
    { 
      
        private IOptionsSnapshot<MySettingsModel> appSettings;
        private IOptionsSnapshot<AuthenInfo> authenSettings;
        private readonly UserInfo userInfo;
        public CategoryController(IOptionsSnapshot<MySettingsModel> app, IOptionsSnapshot<AuthenInfo> authen)
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
        public async Task<IActionResult> GetlstCategory()
        {

            var res = await ApiClientFactory.Instance.GetCategory("");

            return Json(res);
        }

        //[HttpPost]
        //public async Task<IActionResult> InsertlstCategory([FromBody] Category data)
        //{
        //    string json = userInfo.GetUserInfo(HttpContext);

        //    if (json != null)
        //    {
        //        UserInfoModel curUser = JsonConvert.DeserializeObject<UserInfoModel>(json);

        //        //curUser.token = await ApiClientFactory.Instance.RefeshToken(curUser);

        //        var res = await ApiClientFactory.Instance.InsertlstCategory(data, curUser.username, "");

        //        return Json(res);
        //    }
        //    return null;
        //}

        //[HttpPost]
        //public async Task<IActionResult> UpdatelstCategory([FromBody] Category data, [FromQuery] string value)
        //{
        //    string json = userInfo.GetUserInfo(HttpContext);
        //    JsonConvert.PopulateObject(value, data);
        //    if (json != null)
        //    {
        //        UserInfoModel curUser = JsonConvert.DeserializeObject<UserInfoModel>(json);

        //        curUser.token = await ApiClientFactory.Instance.RefeshToken(curUser);

        //        var res = await ApiClientFactory.Instance.UpdatelstCategory(data, curUser.username, curUser.token);

        //        return Json(res);

        //    }
        //    return null;
        //}
        //[HttpDelete]
        //public async Task<IActionResult> DeletelstCategory(string id)
        //{
        //    string json = userInfo.GetUserInfo(HttpContext);

        //    if (json != null)
        //    {
        //        UserInfoModel curUser = JsonConvert.DeserializeObject<UserInfoModel>(json);

        //        curUser.token = await ApiClientFactory.Instance.RefeshToken(curUser);

        //        var res = await ApiClientFactory.Instance.DeletelstCategory(id, curUser.token);

        //        return Json(res);
        //    }

        //    return null;
        //}
    }
}
