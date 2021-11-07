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
    public class ProductSizeController : Controller
    {

        private IOptionsSnapshot<MySettingsModel> appSettings;
        private IOptionsSnapshot<AuthenInfo> authenSettings;
        private readonly UserInfo userInfo;
        public ProductSizeController(IOptionsSnapshot<MySettingsModel> app, IOptionsSnapshot<AuthenInfo> authen)
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
                ViewBag.Product = res;
                return View();
            }
            return RedirectToAction("Index", "Login");
        }


        [HttpGet]
        public async Task<IActionResult> GetlstProductSize()
        {
            string json = userInfo.GetUserInfo(HttpContext);

            if (json != null)
            {
                var res = await ApiClientFactory.Instance.GetProductSize("");
                return Json(res);
            }
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public async Task<IActionResult> InsertlstProductSize([FromBody] ProductSize data)
        {
            string json = userInfo.GetUserInfo(HttpContext);

            if (json != null)
            {
                //UserInfoModel curUser = JsonConvert.DeserializeObject<UserInfoModel>(json);

                //curUser.token = await ApiClientFactory.Instance.RefeshToken(curUser);

                var res = await ApiClientFactory.Instance.InsertProductSize(data, "", "");

                return Json(res);
            }
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public async Task<IActionResult> UpdatelstProductSize([FromBody] ProductSize data, [FromQuery] string value)
        {
            string json = userInfo.GetUserInfo(HttpContext);
            JsonConvert.PopulateObject(value, data);
            if (json != null)
            {
                //    UserInfoModel curUser = JsonConvert.DeserializeObject<UserInfoModel>(json);

                //    curUser.token = await ApiClientFactory.Instance.RefeshToken(curUser);

                var res = await ApiClientFactory.Instance.UpdateProductSize(data, "", "");

                return Json(res);

            }
            return RedirectToAction("Index", "Login");
        }
        //[HttpDelete]
        //public async Task<IActionResult> DeletelstProductSize(string id)
        //{
        //    string json = userInfo.GetUserInfo(HttpContext);

        //    if (json != null)
        //    {
        //        UserInfoModel curUser = JsonConvert.DeserializeObject<UserInfoModel>(json);

        //        curUser.token = await ApiClientFactory.Instance.RefeshToken(curUser);

        //        var res = await ApiClientFactory.Instance.DeletelstProductSize(id, curUser.token);

        //        return Json(res);
        //    }

        //    return null;
        //}
    }
}
