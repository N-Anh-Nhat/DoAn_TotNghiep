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
                var res = await ApiClientFactory.Instance.GetOrder("");
                List<Orders> data = new List<Orders>();
                foreach(var item in res)
                {
                    if (item.Status == false)
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
                var res = await ApiClientFactory.Instance.GetOrder_detailById(id,"");
               
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

            var res = await ApiClientFactory.Instance.InsertOrder(data, "", "");

            return Json(res);
            ////}
            //return null;
        }

        [HttpPost]
        public async Task<IActionResult> UpdatelstOrder([FromBody] Orders data)
        {
            string json = userInfo.GetUserInfo(HttpContext);

            if (json != null)
            {
                
                data.Status = true;
                var res = await ApiClientFactory.Instance.UpdateOrder(data, "", "");

                return Json(res);

            }
            return RedirectToAction("Index", "Login");
        }
        
    }
}
