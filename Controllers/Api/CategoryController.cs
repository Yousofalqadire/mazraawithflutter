using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc.Routing;
using Mazaare3.Interfaces;
using Mazaare3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ControllerBase = Microsoft.AspNetCore.Mvc.ControllerBase;

namespace Mazaare3.Controllers.Api
{
    [ApiController]
    [Route("api/category")]
    public class CategoryController:ControllerBase
    {
        private readonly ICategory category;

        public CategoryController(ICategory category)
        {
            this.category = category;
        }
       [HttpGet]
public async Task<ActionResult<IEnumerable<Category>>> getCategories()
 {
    return Ok(await category.GetCategoriesAsync());

 }
 }
}