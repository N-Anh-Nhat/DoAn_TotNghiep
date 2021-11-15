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
    public class IndexController : Controller
    {
        private IOptionsSnapshot<MySettingsModel> appSettings;
        private IOptionsSnapshot<AuthenInfo> authenSettings;
        private readonly UserInfo userInfo;
        public IndexController(IOptionsSnapshot<MySettingsModel> app, IOptionsSnapshot<AuthenInfo> authen)
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
                var Token = await ApiClientFactory.Instance.GetTokenAsync();
                int DemDonDaBan = 0;
                int DemDonChuaBan = 0;
                var res = await ApiClientFactory.Instance.GetOrder(Token);
                var res1 = await ApiClientFactory.Instance.GetProduct(Token);
                decimal sum = 0;
                foreach (var item in res)
                {
                    if (item.ID_TrangThaiDonHang == 3)
                    {
                        DemDonDaBan++;
                        if(item.CreatedDate.Month == DateTime.Now.Month)
                        {
                           
                            sum += item.ToTal_Money; 
                        }
                        
                    }
                       
                    if (item.ID_TrangThaiDonHang == 1)
                        DemDonChuaBan++;
                }
                ViewData["CountProduct"] = res1.Count();
                ViewData["CountDonChuaBan"] = DemDonChuaBan;
                ViewData["CountDon"] = DemDonDaBan;
                ViewData["DoanhThuThang"] = sum;
                var data = await ApiClientFactory.Instance.GetReportOrder(2021, Token);
                ViewBag.Report = data;
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
                var Token = await ApiClientFactory.Instance.GetTokenAsync();
                var res = await ApiClientFactory.Instance.GetOrder(Token);
                List<Orders> data = new List<Orders>();
                foreach (var item in res)
                {
                    if (item.Status == true)
                        data.Add(item);
                }
                return Json(data);
            }
            return RedirectToAction("Index", "Login");
        }
        [HttpGet]
        public async Task<IActionResult> GetReportOrder(int pYear)
        {
            string json = userInfo.GetUserInfo(HttpContext);

            if (json != null)
            {
                var Token = await ApiClientFactory.Instance.GetTokenAsync();
                var res = await ApiClientFactory.Instance.GetReportOrder(2021,Token);
                
                return Json(res);
            }
            return RedirectToAction("Index", "Login");
        }
    }
}
