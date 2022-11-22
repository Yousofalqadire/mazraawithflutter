using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc.Routing;
using API.Extintions;
using API.Helpers;
using Mazaare3.Interfaces;
using Mazaare3.Models;
using Mazaare3.Models.ViewModel;
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
        private readonly IAds ads;

        public AdsControllers(AppDBContext db,IAds ads)
        {
            this.db = db;
            this.ads = ads;
        }
        [HttpGet]
        [Route("get-all-ads")]
        public async Task<ActionResult<IEnumerable<Ad>>> GetAllAds([FromQuery]UserParams model)
        {
            var result = await ads.GetAllAdsAsync(model);
            Response.AddPaginationHeader(result.CurrentPage,result.PageSize,result.TotalCount,result.TotalPage);
            return Ok(result);
        }
       
         [HttpGet("get-ad-details/{id:int}")]

         public async Task<ActionResult<AdDetail>> GetAdById([FromRoute]int id)
         {
            return Ok(await ads.GetAdByIdAsync(id));
         } 

        [HttpGet("get-by-category/{name}")]
         
         public async Task<ActionResult<IEnumerable<Ad>>> GetAdByCategory([FromRoute]string name)
         {
            var result = await ads.GetAdByCategoryAsync(name);
            return Ok(result);
         } 
       
    }
}