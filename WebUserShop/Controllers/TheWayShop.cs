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
using X.PagedList;

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

            //danh sách sp
            var res = await ApiClientFactory.Instance.GetProduct("");
            ViewBag.TotalSp = res.Where(s => s.Status == true).Count();
            ViewBag.ListSp = res.Where(s => s.Status == true).ToList();

            //danh sách loại sp
            var category = await ApiClientFactory.Instance.GetCategory("");
            ViewBag.ListCategory = category.Where(s => s.Status == true).ToList();

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

            //
            var datasp = from m in res
                         where m.Status == true
                         select m;


            var pageSize = 6;
            var PageNumber = page ?? 1;
            var datalistpage = res.Where(s => s.Status == true).ToList();

            //tìm kiếm
            if (!String.IsNullOrWhiteSpace(txtSearch))
            {
                datasp = datasp.Where(s => s.Name.Contains(txtSearch));
                ViewBag.totalSpSearch = datasp.Count();              
                ViewBag.posts = datasp.ToPagedList(PageNumber, pageSize);
            }
            else
            {
                ViewBag.posts = datalistpage.ToPagedList(PageNumber, pageSize);
            }

            //sắp xếp
            //ViewBag.NameSort = String.IsNullOrEmpty(sort) ? "PriceLowToHigh" : "PriceHighToLow";
            //switch (sort)
            //{
            //    case "PriceLowToHigh":
            //        ViewBag.posts = datalistpage.ToPagedList(PageNumber, pageSize).OrderBy(s => s.Price).Take(pageSize);
            //        break;
            //    case "PriceHighToLow":
            //        ViewBag.posts = datalistpage.ToPagedList(PageNumber, pageSize).OrderByDescending(x => x.Price).Take(pageSize);
            //        break;
            //    default:
            //        ViewBag.posts = res.ToPagedList(PageNumber, pageSize).OrderBy(x => x.ID);
            //        break;
            //}



            return View();
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
