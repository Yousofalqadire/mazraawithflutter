using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mazaare3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace Mazaare3.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class AdsController : Controller
    {
        private readonly AppDBContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public AdsController(AppDBContext context , IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
            _context = context;
 
        }

        // GET: Administrator/Ads
        public async Task<IActionResult> Index()
        {
            ViewBag.SessionV = HttpContext.Session.GetString("Name");
            ViewBag.SessionRoleID = HttpContext.Session.GetString("RoleId");
            return View(await _context.Ads.ToListAsync());
        }

        // GET: Administrator/Ads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewBag.SessionV = HttpContext.Session.GetString("Name");
            ViewBag.SessionRoleID = HttpContext.Session.GetString("RoleId");
            if (id == null)
            {
                return NotFound();
            }

            var ad = await _context.Ads
                .FirstOrDefaultAsync(m => m.AdId == id);
            if (ad == null)
            {
                return NotFound();
            }

            return View(ad);
        }

        // GET: Administrator/Ads/Create
        public IActionResult Create()
        {
            ViewBag.SessionV = HttpContext.Session.GetString("Name");
            ViewBag.SessionRoleID = HttpContext.Session.GetString("RoleId");
            ViewBag.allCategories = new SelectList(_context.Categories, "CategoryName", "CategoryName");
            ViewBag.allFloors = new SelectList(_context.Floors, "FloorName", "FloorName");
            ViewBag.allAddresses = new SelectList(_context.Addresses, "AddressName", "AddressName");
            ViewBag.allRooms = new SelectList(_context.Rooms, "RoomName", "RoomName");
            return View();
        }

        // POST: Administrator/Ads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AdId,Title,Category,Price,Mobile,AlterMobile,Email,IsApproved,CoverImage,PostedDate,Address,Floors,Rooms")] Ad ad)
        {
            ViewBag.SessionV = HttpContext.Session.GetString("Name");
            ViewBag.SessionRoleID = HttpContext.Session.GetString("RoleId");
            ViewBag.allCategories = new SelectList(_context.Categories, "CategoryName", "CategoryName");
            ViewBag.allAddresses = new SelectList(_context.Addresses, "AddressName", "AddressName");
            ViewBag.allFloors = new SelectList(_context.Floors, "FloorName", "FloorName");
            ViewBag.allRooms = new SelectList(_context.Rooms, "RoomName", "RoomName");
            if (ModelState.IsValid)
            { 
                ad.PostedDate = DateTime.Now;
                _context.Add(ad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ad);
        }

        // GET: Administrator/Ads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.SessionV = HttpContext.Session.GetString("Name");
            ViewBag.SessionRoleID = HttpContext.Session.GetString("RoleId");
            ViewBag.allCategories = new SelectList(_context.Categories, "CategoryName", "CategoryName");
            ViewBag.allFloors = new SelectList(_context.Floors, "FloorName", "FloorName");
            ViewBag.allAddresses = new SelectList(_context.Addresses, "AddressName", "AddressName");
            ViewBag.allRooms = new SelectList(_context.Rooms, "RoomName", "RoomName");
            if (id == null)
            {
                return NotFound();
            }

            var ad = await _context.Ads.FindAsync(id);
            if (ad == null)
            {
                return NotFound();
            }
            return View(ad);
        }

        // POST: Administrator/Ads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AdId,Title,Category,Price,Mobile,AlterMobile,Email,IsApproved,CoverImage,PostedDate,Address,Floors,Rooms")] Ad ad)
        {
            ViewBag.SessionV = HttpContext.Session.GetString("Name");
            ViewBag.SessionRoleID = HttpContext.Session.GetString("RoleId");
            ViewBag.allCategories = new SelectList(_context.Categories, "CategoryName", "CategoryName");
            ViewBag.allAddresses = new SelectList(_context.Addresses, "AddressName", "AddressName");
            ViewBag.allFloors = new SelectList(_context.Floors, "FloorName", "FloorName");
            ViewBag.allRooms = new SelectList(_context.Rooms, "RoomName", "RoomName");
            if (id != ad.AdId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdExists(ad.AdId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ad);
        }

        // GET: Administrator/Ads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            ViewBag.SessionV = HttpContext.Session.GetString("Name");
            ViewBag.SessionRoleID = HttpContext.Session.GetString("RoleId");
            ViewBag.allCategories = new SelectList(_context.Categories, "CategoryName", "CategoryName");
            ViewBag.allAddresses = new SelectList(_context.Addresses, "AddressName", "AddressName");
            ViewBag.allFloors = new SelectList(_context.Floors, "FloorName", "FloorName");
            ViewBag.allRooms = new SelectList(_context.Rooms, "RoomName", "RoomName");
            if (id == null)
            {
                return NotFound();
            }

            var ad = await _context.Ads
                .FirstOrDefaultAsync(m => m.AdId == id);
            if (ad == null)
            {
                return NotFound();
            }

            return View(ad);
        }

        // POST: Administrator/Ads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ad = await _context.Ads.FindAsync(id);
            _context.Ads.Remove(ad);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdExists(int id)
        {
            return _context.Ads.Any(e => e.AdId == id);
        }

        public IActionResult AddImgPage(int? id)
        {
            UImages vm = new UImages();
            ViewBag.SessionV = HttpContext.Session.GetString("Name");
            ViewBag.SessionUserId = HttpContext.Session.GetString("UserId");
            ViewBag.SessionRoleID = HttpContext.Session.GetString("RoleId");
            ViewBag.images = new SelectList(_context.Ads.ToList(), "AdId", "Email");
           // var ad =   _context.Ads.FindAsync(id);
            ViewBag.ID = id;

            return View(vm);

        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult AddImgPage(int id , UImages vm, CoverImage ci)
        {
            //var ad = _context.Ads.FindAsync(id);
            ViewBag.ID = id;
            ViewBag.SessionV = HttpContext.Session.GetString("Name");
            ViewBag.SessionRoleID = HttpContext.Session.GetString("RoleId");
            if (ModelState.IsValid)
            {
                string stringFileNameCover = UploadFile(vm.CoverImage);
                var usercoverImage = new CoverImage
                {
                    CoverImageURL = stringFileNameCover,
                    AdId = vm.AdId
                };

                _context.CoverImages.Add(usercoverImage);
                var x = vm.AdId;


                foreach (var item in vm.Images)
                {
                    string stringFileName = UploadFile(item);

                    var userImage = new UserImage
                    {
                        ImageURL = stringFileName,
                        AdId = vm.AdId

                    };

                    _context.userImages.Add(userImage);


                }

                _context.SaveChanges();

            }

            return RedirectToAction("Index");
        }
        private string UploadFile(IFormFile file)
        {
            string filename = null;
            if (file != null)
            {
                string UploadDir = Path.Combine(_hostEnvironment.WebRootPath + "/uploads/", "uploads");
                filename = Guid.NewGuid().ToString() + "-" + file.FileName;
                string filePath = Path.Combine(UploadDir + filename);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                { file.CopyTo(fileStream); }
            }
            return filename;
        }
    }
}
