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
    public class NewsController : Controller
    {

        private IOptionsSnapshot<MySettingsModel> appSettings;
        private IOptionsSnapshot<AuthenInfo> authenSettings;
        private readonly UserInfo userInfo;
        private readonly IWebHostEnvironment _env;
        public NewsController(IOptionsSnapshot<MySettingsModel> app, IOptionsSnapshot<AuthenInfo> authen, IWebHostEnvironment env)
        {

            appSettings = app;
            authenSettings = authen;
            ApplicationSettings.WebApiUrl = app.Value.WebApiBaseUrl;
            userInfo = new UserInfo();
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            string json = userInfo.GetUserInfo(HttpContext);

            if (json != null)
            {
                var res = await ApiClientFactory.Instance.GetCategory("");
                ViewBag.listCategory = res;
                return View();
            }
            return RedirectToAction("Index", "Login");
        }


        [HttpGet]
        public async Task<IActionResult> GetlstNews()
        {
            string json = userInfo.GetUserInfo(HttpContext);

            if (json != null)
            {
                var res = await ApiClientFactory.Instance.GetNews("");

                return Json(res);
            }
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public async Task<IActionResult> InsertlstNews(News data, IFormFile file)
        {
            string json = userInfo.GetUserInfo(HttpContext);

            if (json != null)
            {
                //UserInfoModel curUser = JsonConvert.DeserializeObject<UserInfoModel>(json);

                //curUser.token = await ApiClientFactory.Instance.RefeshToken(curUser);
                Message<DataResults<Object>> err = new Message<DataResults<Object>>();
                if (file != null)
                {
                    string filename = GetFileNameWithDate(file.FileName);
                    bool check = SaveFile(file, filename);
                    if (!check)
                    {
                        DataResults<Object> dataResults = new DataResults<object>();

                        err.IsSuccess = true;
                        dataResults.Status = -2;
                        dataResults.Message = "Save file error";
                        err.Data = dataResults;
                        return Json(err);
                    }
                    data.Image = "uploads/New/img/" + filename;


                }

                var res = await ApiClientFactory.Instance.InsertNews(data, "", "");

                return Json(res);
            }
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public async Task<IActionResult> UpdatelstNews(News data, IFormFile file)
        {
            string json = userInfo.GetUserInfo(HttpContext);

            if (json != null)
            {
                
                Message<DataResults<Object>> err = new Message<DataResults<Object>>();
                if (file != null)
                {
                    string filename = GetFileNameWithDate(file.FileName);
                    bool check = SaveFile(file, filename);
                    if (!check)
                    {
                        DataResults<Object> dataResults = new DataResults<object>();

                        err.IsSuccess = true;
                        dataResults.Status = -2;
                        dataResults.Message = "Save file error";
                        err.Data = dataResults;
                        return Json(err);
                    }
                    data.Image = "uploads/New/img/" + filename;


                }

                var res = await ApiClientFactory.Instance.UpdateNews(data, "", "");

                return Json(res);

            }
            return RedirectToAction("Index", "Login");
        }
        //[HttpDelete]
        //public async Task<IActionResult> DeletelstNews(string id)
        //{
        //    string json = userInfo.GetUserInfo(HttpContext);

        //    if (json != null)
        //    {
        //        UserInfoModel curUser = JsonConvert.DeserializeObject<UserInfoModel>(json);

        //        curUser.token = await ApiClientFactory.Instance.RefeshToken(curUser);

        //        var res = await ApiClientFactory.Instance.DeletelstNews(id, curUser.token);

        //        return Json(res);
        //    }

        //    return null;
        //}
        public bool SaveFile(IFormFile file, string name)
        {
            try
            {
                string webRootPath = _env.WebRootPath;
                string newPath = Path.Combine(webRootPath, "uploads/New/img/");
                System.IO.DirectoryInfo di = new DirectoryInfo(newPath);

                if (!Directory.Exists(newPath))
                {
                    Directory.CreateDirectory(newPath);
                }

                using (var fileStream = new FileStream(Path.Combine(newPath, name), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                FileInfo fileLocation = new FileInfo(Path.Combine(newPath, name));

                if (fileLocation.Exists)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        private string GetFileNameWithDate(string filename) =>
            Path.GetFileNameWithoutExtension(filename) +
            DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") +
            Path.GetExtension(filename);
    }
}
