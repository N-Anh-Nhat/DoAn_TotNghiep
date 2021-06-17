using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAdminShop.Controllers
{
    public class Mail_AllController : Controller
    {
        public IActionResult Mail_All()
        {
            return View();
        }
    }
}
