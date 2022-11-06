using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc.Routing;
using Mazaare3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ControllerBase = Microsoft.AspNetCore.Mvc.ControllerBase;

namespace Mazaare3.Controllers.Api
{
       [ApiController]
       [Route("api/ads")]
    
 
    public class AdsControllers : ControllerBase
    {
        private readonly AppDBContext db;

        public AdsControllers(AppDBContext db)
        {
            this.db = db;
        }
        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("get-all-ads")]
        public async Task<ActionResult<IEnumerable<Ad>>> GetAllAds()
        {
            var ads =await db.Ads.ToListAsync();
            return Ok(ads);
        }
    }
}