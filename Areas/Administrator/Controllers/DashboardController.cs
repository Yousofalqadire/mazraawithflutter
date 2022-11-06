using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mazaare3.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.SessionV = HttpContext.Session.GetString("Name");
            ViewBag.SessionRoleID = HttpContext.Session.GetString("RoleId");
            return View();
        }
        public IActionResult RentAds()
        {
            ViewBag.SessionV = HttpContext.Session.GetString("Name");
            ViewBag.SessionRoleID = HttpContext.Session.GetString("RoleId");
            return View();
        }
        public IActionResult SellAds()
        {
            ViewBag.SessionV = HttpContext.Session.GetString("Name");
            ViewBag.SessionRoleID = HttpContext.Session.GetString("RoleId");
            return View();
        }

    }
}
