using LIB.BaseModels;
using LIB.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUserShop.ApiCaller;
using WebAPI.Models;

namespace WebUserShop.Controllers
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
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] User user)
        {
            user.Status = true;
            user.ID_Role = 2;
            var KQ = await ApiClientFactory.Instance.InsertUser(user, "", "");
            return Json(KQ);


        }
        [HttpGet]
        public async Task<IActionResult> GetlstUser(string User)
        {

            var res = await ApiClientFactory.Instance.GetUser("");
            //kiem tra trung user
            var UserCount = res.Where(u => u.UserName.Equals(User)).Select(x => x.ID).Count();
            bool result=UserCount > 0 ? false : true;
            return Json(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetlstUserofMail(string mail)
        {

            var resMail = await ApiClientFactory.Instance.GetUser("");
            //kiem tra trung user
            var mailCount = resMail.Where(u => u.Email.Equals(mail)).Select(x => x.ID).Count();
            bool result = mailCount > 0 ? false : true;
            return Json(result);
        }

    }
}
