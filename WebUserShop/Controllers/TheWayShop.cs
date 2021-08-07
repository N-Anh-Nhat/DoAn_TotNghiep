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
using WebAdminShop.ApiCaller;
using WebAPI.Models;
using PagedList;

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
        public IActionResult Cart()
        {
            return View();
        }
        public IActionResult Contact_Us()
        {
            return View();
        }
        public IActionResult My_Account()
        {
            return View();
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
        public async Task<IActionResult> Product(string txtSearch, int? page, string sort)
        {
            Product product = new Product();
            //danh sách sp
            var res = await ApiClientFactory.Instance.GetProduct("");
            ViewBag.TotalSp = res.Where(s => s.Status == true).Count();
            ViewBag.ListSp = res.Where(s => s.Status == true).ToList();

            //danh sách loại sp
            var category = await ApiClientFactory.Instance.GetCategory("");
            ViewBag.ListCategory = category.Where(s => s.Status == true).ToList();
            //ViewBag.ListSp = category.Where(s => s.Status == true && s.ID==product.ID_Catelogy).GroupBy(s=>s.Name).Count();

            //tổng sản phẩm của loại sản phẩm
            var taisan = from s in category
                         join x in res on s.ID equals x.ID_Catelogy
                         group s by s.ID into g
                         select
                         (
                             g.FirstOrDefault().Name,
                             g.Count()
                         );
            ViewBag.totalSPCate = taisan;

            //tìm kiếm
            var datasp = from m in res
                         where m.Status == true
                         select m;

            if (!String.IsNullOrWhiteSpace(txtSearch))
            {
                datasp = datasp.Where(s => s.Name.Contains(txtSearch));
                ViewBag.posts = datasp;              
            }
            
            //phân trang
            
            if (page > 0)
            {
                page = page;
            }
            else
            {
                page = 1;
            }
            int pageSize = 6;
            int start = (int)(page - 1) * pageSize;

            ViewBag.pageCurrent = page;
            int totalPage = ViewBag.TotalSp;
            float totalNumsize = (totalPage / (float)pageSize);
            int numSize = (int)Math.Ceiling(totalNumsize);
            ViewBag.numSize = numSize;
            ViewBag.posts = datasp.OrderBy(x => x.ID).Skip(start).Take(pageSize);
            


            //sắp xếp

            
                //ViewBag.NameSort = String.IsNullOrEmpty(sort) ? "PriceLowToHigh" : "PriceHighToLow";
            //switch (sort)
            //{
            //    case "PriceLowToHigh":
            //        ViewBag.posts = datasp.OrderBy(x => x.Price).Skip(start).Take(pageSize);
            //        break;
            //    case "PriceHighToLow":
            //        ViewBag.posts = datasp.OrderByDescending(x => x.Price).Skip(start).Take(pageSize);
            //        break;
            //    default:
            //        ViewBag.posts = datasp.OrderBy(x => x.ID).Skip(start).Take(pageSize);
            //        break;
            //}

                
            
            return View();
        }
       public void Search()
        {

        }
        public async Task<IActionResult> Product_detail(int? id)
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
            ViewBag.ProSize = prosize.Where(s => s.Status == true).ToList();
            return View(proDetail);
        }
        public IActionResult Wish_List()
        {
            return View();
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
