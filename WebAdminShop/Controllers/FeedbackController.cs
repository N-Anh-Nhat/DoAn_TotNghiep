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
    public class FeedbackController : Controller
    {

        private IOptionsSnapshot<MySettingsModel> appSettings;
        private IOptionsSnapshot<AuthenInfo> authenSettings;
        private readonly UserInfo userInfo;
        public FeedbackController(IOptionsSnapshot<MySettingsModel> app, IOptionsSnapshot<AuthenInfo> authen)
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
        public async Task<IActionResult> GetlstFeedback()
        {

            var res = await ApiClientFactory.Instance.GetFeedback("");

            return Json(res);
        }

        [HttpPost]
        public async Task<IActionResult> InsertlstFeedback([FromBody] Feedback data)
        {
            //string json = userInfo.GetFeedbackInfo(HttpContext);

            //if (json != null)
            //{
            //FeedbackInfoModel curFeedback = JsonConvert.DeserializeObject<FeedbackInfoModel>(json);

            //curFeedback.token = await ApiClientFactory.Instance.RefeshToken(curFeedback);

            var res = await ApiClientFactory.Instance.InsertFeedback(data, "", "");

            return Json(res);
            ////}
            //return null;
        }

        [HttpPost]
        public async Task<IActionResult> UpdatelstFeedback([FromBody] Feedback data, [FromQuery] string value)
        {
            //string json = userInfo.GetFeedbackInfo(HttpContext);
            JsonConvert.PopulateObject(value, data);
            //if (json != null)
            //{
            //    FeedbackInfoModel curFeedback = JsonConvert.DeserializeObject<FeedbackInfoModel>(json);

            //    curFeedback.token = await ApiClientFactory.Instance.RefeshToken(curFeedback);

            var res = await ApiClientFactory.Instance.UpdateFeedback(data, "", "");

            return Json(res);

            //}
            //return null;
        }
        //[HttpDelete]
        //public async Task<IActionResult> DeletelstFeedback(string id)
        //{
        //    string json = userInfo.GetFeedbackInfo(HttpContext);

        //    if (json != null)
        //    {
        //        FeedbackInfoModel curFeedback = JsonConvert.DeserializeObject<FeedbackInfoModel>(json);

        //        curFeedback.token = await ApiClientFactory.Instance.RefeshToken(curFeedback);

        //        var res = await ApiClientFactory.Instance.DeletelstFeedback(id, curFeedback.token);

        //        return Json(res);
        //    }

        //    return null;
        //}
    }
}
