using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAdminShop.Controllers
{
    public class Blog_AddController : Controller
    {
        public IActionResult Blog_Add()
        {
            return View();
        }
    }
}
