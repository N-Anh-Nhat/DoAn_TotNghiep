using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAdminShop.Controllers
{
    public class SlideController : Controller
    {
        public IActionResult Slide()
        {
            return View();
        }
    }
}
