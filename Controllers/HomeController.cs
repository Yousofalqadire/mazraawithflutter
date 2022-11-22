using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Microsoft.Owin;
using Mazaare3.Models;
 using System.Web.Mvc.Html; 
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using PagedList;
using Microsoft.AspNetCore.Html;
using Mazaare3.Models.ViewModel;

namespace Mazaare3.Controllers
{
    public class HomeController : Controller
    {
        private AppDBContext db;
 

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger , AppDBContext _db)
        {
            _logger = logger;
            db = _db;
        }

        public IActionResult Index()
        {
            return View();
        }
        
      public IActionResult JoinUs()
        {
            return View();
        }
        public  IActionResult Logout()
        {
          
            HttpContext.Session.SetString("RoleId", "0");
            HttpContext.Session.SetString("Name", "0");
            //HttpContext.Session.SetString("UserId", "0");

            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public IActionResult Register(LoginViewModel model, User users)
        {
            if (ModelState.IsValid)
            {

                //users.AdminRoleId = 7;
                //user.IsApproved = false;

                db.AppUsers.Add(users); 
                db.SaveChanges();
                //HttpContext.Session.SetString("RoleId", user.AdminRoleId.ToString());
                //HttpContext.Session.SetString("Name", user.FullName.ToString());
                //HttpContext.Session.SetString("UserId", user.AdminUserId.ToString());
                //return RedirectToAction("Welcome", "Home", new { userID = user.AdminUserId });
                return RedirectToAction("Index");


            }
            //ModelState.AddModelError(string.Empty, "The user name or password is incorrect");
            return View();
          

        }
        [HttpPost]
        public  IActionResult  JoinUs( LoginViewModel model , User users)
        {
             
            var chkUser = db.AppUsers.Where(x => x.Email.Equals(users.Email) && x.Password.Equals(users.Password));

            if (chkUser.Any())
            {
                //HttpContext.Session.SetString("RoleId", chkUser.SingleOrDefault().AdminRoleId.ToString());
                //HttpContext.Session.SetString("Name", chkUser.SingleOrDefault().FullName.ToString());
                //HttpContext.Session.SetString("UserId", chkUser.SingleOrDefault().AdminUserId.ToString());

                //if (chkUser.SingleOrDefault().AdminRoleId == 1)
                //{


                //    return RedirectToAction("Index", "Dashboard", new { area = "Administrator" });

                //}
                //else
                //{
                //    return RedirectToAction("Welcome", "Home", new { userID = user.AdminUserId });
                //}

                //}
                //else
                //{

                //    ModelState.AddModelError(string.Empty, "The user name or password is incorrect");

                return RedirectToAction("Index");
            }
            ModelState.AddModelError(string.Empty, "The user name or password is incorrect");
            return View(model);


        }

        public async Task<ActionResult<PagedList<Ad>>> Rent(string AddressName, string RoomName, string FloorName, string maxRange, string minRange, int pageNumber = 1)
        {
            // string email = maxRange.Value.ToString();
            //MaxSlider = 0;
            //MinSlider = 0; 
            //maxRange =
            //  var mPrice = Convert.ToDouble(minRange);
            //  var maxPrice = Convert.ToDouble(maxRange);  

            foreach (var item in db.Ads)
            {
                foreach (var x in db.CoverImages)
                {
                    if (item.AdId == x.AdId)
                    {
                        item.CoverImage = "/uploads/uploads" + x.CoverImageURL;
                        //ViewBag.CoverImageUser = "/uploads/uploads" + x.CoverImageURL;
                    }
                }

            }
            ViewBag.allCategories = new SelectList(db.Categories, "CategoryName", "CategoryName");
            ViewBag.allFloors = new SelectList(db.Floors, "FloorName", "FloorName");
            ViewBag.allAddresses = new SelectList(db.Addresses, "AddressName", "AddressName");
            ViewBag.allRooms = new SelectList(db.Rooms, "RoomName", "RoomName");
            var result = db.Ads.Where(x=>x.Category == "Rent").AsQueryable();
            if (!string.IsNullOrEmpty(AddressName))
                result = result.Where(x => x.Address == AddressName);
            if (!string.IsNullOrEmpty(RoomName))
                result = result.Where(x => x.Rooms == RoomName);
            if (!string.IsNullOrEmpty(FloorName))
                result = result.Where(x => x.Floors == FloorName);
            if (!string.IsNullOrEmpty(minRange))
               result = result.Where(x => x.Price >= Convert.ToDouble(minRange));
            if (!string.IsNullOrEmpty(maxRange))
                result = result.Where(x => x.Price <= Convert.ToDouble(maxRange));
            return View(await PaginatedList<Ad>.CreateAsync(result, pageNumber, 8));
        }

        public IActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AdminLogin(LoginViewModel model, Admin admins)
        {

            var chkUser = db.Admins.Where(x => x.Email.Equals(admins.Email) && x.Password.Equals(admins.Password));

            if (chkUser.Any())
            {
                HttpContext.Session.SetString("RoleId", "1");
                HttpContext.Session.SetString("Name", chkUser.SingleOrDefault().FullName.ToString());
                // HttpContext.Session.SetString("UserId", chkUser.SingleOrDefault().AdminUserId.ToString());

                if ( HttpContext.Session.GetString("RoleId") == "1")
                {


                    return RedirectToAction("Index", "Dashboard", new { area = "Administrator" });

                }
                else
                {
                    return RedirectToAction("Index", "Home" );
                } 
               // return RedirectToAction("Index");
            }
            ModelState.AddModelError(string.Empty, "The user name or password is incorrect");
            return View(model);


        }
        [HttpGet]
   
        public async Task<ActionResult> Sell(string AddressName, string RoomName, string FloorName
         , string maxRange, string minRange, int pageNumber = 1)
        {
            // string email = maxRange.Value.ToString();
            //MaxSlider = 0;
            //MinSlider = 0; 
            //maxRange =  

            foreach (var item in db.Ads)
            {
                foreach (var x in db.CoverImages)
                {
                    if (item.AdId == x.AdId)
                    {
                        item.CoverImage = "/uploads/uploads" + x.CoverImageURL;
                        //ViewBag.CoverImageUser = "/uploads/uploads" + x.CoverImageURL;
                    }
                }

            }
            ViewBag.allCategories = new SelectList(db.Categories, "CategoryName", "CategoryName");
            ViewBag.allFloors = new SelectList(db.Floors, "FloorName", "FloorName");
            ViewBag.allAddresses = new SelectList(db.Addresses, "AddressName", "AddressName");
            ViewBag.allRooms = new SelectList(db.Rooms, "RoomName", "RoomName");
            var result = db.Ads.Where(x => x.Category == "Sell").AsQueryable();
            if (!string.IsNullOrEmpty(AddressName))
                result = result.Where(x => x.Address == AddressName);
            if (!string.IsNullOrEmpty(RoomName))
                result = result.Where(x => x.Rooms == RoomName);
            if (!string.IsNullOrEmpty(FloorName))
                result = result.Where(x => x.Floors == FloorName);
            if (!string.IsNullOrEmpty(minRange))
                result = result.Where(x => x.Price >= Convert.ToDouble(minRange));
            if (!string.IsNullOrEmpty(maxRange))
             result = result.Where(x => x.Price <= Convert.ToDouble(maxRange));
            return View(await PaginatedList<Ad>.CreateAsync(result, pageNumber, 8)); 
        }

        public ActionResult AdDetails(int id)
        {
            ViewBag.UserId = id;
            //ViewBag.Cover = "/uploads/uploads" + db.AdminUsers.Find(id).CoverImage;
            //foreach (var item in db.CoverImages)
            //{
            //    if (item.AdId == db.Ads.Find(id).AdId)
            //    {
            //        ViewBag.Cover = "/uploads/uploads" + db.CoverImages.Find(item.CoverImageId).CoverImageURL;
            //    }
            //}

            var data = db.Ads.Find(id);
            return View(db.Ads.Find(id));

        }
        public IActionResult About()
        {
            return View();
        }
        [HttpGet]



        public IActionResult Services()
        {
            return View();
        }
        
     public IActionResult ContactUs()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ContactUs(ContactUs pro)
        {

            if (ModelState.IsValid)
            {
                db.Contacts.Add(pro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();


        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
