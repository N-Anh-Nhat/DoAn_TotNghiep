using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUserShop.Controllers
{
    public class TheWayShop : Controller
    {
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
        public IActionResult CheckOut()
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
        public IActionResult NEWS()
        {
            return View();
        }
        public IActionResult News_Detail()
        {
            return View();
        }
        public IActionResult Product()
        {
            return View();
        }
        public IActionResult Product_detail()
        {
            return View();
        }
        public IActionResult Wish_List()
        {
            return View();
        }
    }
}
