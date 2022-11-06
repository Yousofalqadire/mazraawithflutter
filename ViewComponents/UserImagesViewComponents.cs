using Mazaare3.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mazaare3.ViewComponents
{
    public class UserImagesViewComponent : ViewComponent
    {
        private AppDBContext db;
        public UserImagesViewComponent(AppDBContext _db)
        {
            db = _db;
        }

        public IViewComponentResult Invoke()
        {
            return View(db.userImages.OrderBy(x => x.Id));
        }
    }
}
