using LIB.BaseModels;
using LIB.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Options;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUserShop.ApiCaller;
using WebAPI.Models;
using X.PagedList;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Data.SqlClient;

namespace WebUserShop.Controllers
{
    public class TheWayShop : Controller
    {
        private IOptionsSnapshot<MySettingsModel> appSettings;
        private IOptionsSnapshot<AuthenInfo> authenSettings;
        private readonly UserInfo userInfo;
        public TheWayShop(IOptionsSnapshot<MySettingsModel> app, IOptionsSnapshot<AuthenInfo> authen)
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
        public IActionResult About()
        {
            return View();
        }
        
        public IActionResult Contact_Us()
        {
            return View();
        }

        //gửi phản hồi
        [HttpPost]
        public async Task<IActionResult> SendFeedback([FromBody] Feedback feedback)
        {

            feedback.Status = true;
            var sendFB = await ApiClientFactory.Instance.InsertFeedback(feedback, "", "");
            return Json(sendFB);
        }
        public IActionResult My_Account()
        {
            if (HttpContext.Session.GetString("user1") != null)
            {
                string a = HttpContext.Session.GetString("user1");
                var user = JsonConvert.DeserializeObject<User>(a);
                ViewBag.infoUser = user;
                return View();
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> EditAccount([FromBody] User user)
        {
            user.ModifiedDate = DateTime.Now;
            var editUser = await ApiClientFactory.Instance.UpdateUser(user, "", "");


           



            return Json(true);
        }
        public async Task<IActionResult> NEWS()
        {
            var listnews = await ApiClientFactory.Instance.GetNews("");
            var category1 = await ApiClientFactory.Instance.GetCategory("");

            ViewBag.ListNews = listnews.Where(s => s.Status == true).ToList();
            return View();
        }
        public IActionResult News_Detail()
        {
            return View();
        }
        public async Task<IActionResult> Product(string txtSearch,int? categoryID, int? page, string sort)
        {
           
            //danh sách sp
            var product = await ApiClientFactory.Instance.GetProduct("");
            ViewBag.TotalSp = product.Where(s => s.Status == true).Count();
            ViewBag.ListSp = product.Where(s => s.Status == true).ToList();

            //danh sách loại sp
            var category = await ApiClientFactory.Instance.GetCategory("");
            ViewBag.ListCategory = category.Where(s => s.Status == true).ToList();

            //tổng sản phẩm của loại sản phẩm
            var taisan = from s in category
                         join x in product on s.ID equals x.ID_Catelogy
                         group s by s.ID into g
                         select
                         (
                             g.FirstOrDefault().Name,
                             g.Count()
                         );
            ViewBag.totalSPCate = taisan;

            // list product
            var datasp = from m in product
                         where m.Status == true
                         select m;

            //kích thước sản phẩm trong 1 trang
            var pageSize = 3;
            var PageNumber = page ?? 1;
            ViewBag.Sort = sort;
            ViewBag.categoryID = categoryID;


            //fliter and sort product
            if (categoryID != null)
            {
                datasp = (from m in product
                          join x in category on m.ID_Catelogy equals x.ID
                          where x.ID == categoryID
                          select m);
            }
            if (sort !=null)
            {
                switch (sort)
                {
                    case "PriceLowToHigh":
                        datasp = datasp.OrderBy(s => s.Price);
                        break;
                    case "PriceHighToLow":
                        datasp = datasp.OrderByDescending(s => s.Price);                   
                        break;
                    case "CharA_Z":
                        datasp = datasp.OrderBy(s => s.Name);
                        break;
                    case "CharZ_A":
                        datasp = datasp.OrderByDescending(s => s.Name);
                        break;
                }
            }           
            else
            {
                ViewBag.posts = datasp.ToPagedList(PageNumber, pageSize);
            }
            ViewBag.posts = datasp.ToPagedList(PageNumber, pageSize);


            //search product
            ViewBag.txtSearch = txtSearch;
            if (!string.IsNullOrEmpty(txtSearch))
            {
                datasp = datasp.Where(s => s.Name.Contains(txtSearch));
                ViewBag.totalSpSearch = datasp.Count();              
                ViewBag.posts = datasp.ToPagedList(PageNumber, pageSize);
            }
            



            return View();
        }
        public async Task<IActionResult> Product_detail(int? id,int? category)
        {
            if (id == null)
            {
                return NotFound();
            }
            var a = await ApiClientFactory.Instance.GetProduct("");
            var proDetail = a.FirstOrDefault(s => s.ID == id);


            //lấy kích thước sp
            var b = await ApiClientFactory.Instance.GetProductSize("");
            var prosize = b.Where(s => s.ID_Product == id);
            ViewBag.TotalSize = prosize.Count();
            ViewBag.ProSize = prosize.Where(s => s.Status == true).ToList();

            //sản phẩm cùng danh mục
            var ProOfCategory = a.Where(s => s.ID_Catelogy == category && !(s.ID==id)).Take(4);                        
            ViewBag.ProOfCategory = ProOfCategory.Where(s => s.Status == true).ToList();
            return View(proDetail);
        }
        public IActionResult Wish_List()
        {
            if (HttpContext.Session.GetString("user1") != null)
            {
                return View();
            }
            return NotFound();
        }
        public IActionResult Chinh_sach_doi_tra()
        {
            return View();
        }
        public IActionResult Chinh_sach_bao_hanh()
        {
            return View();
        }
    }
}
