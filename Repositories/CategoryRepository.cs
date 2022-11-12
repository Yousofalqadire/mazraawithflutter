using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mazaare3.Models;
using Microsoft.EntityFrameworkCore;

namespace Mazaare3.Interfaces.Repositories
{
    public class CategoryRepository : ICategory
    {
        private readonly AppDBContext db;

        public CategoryRepository(AppDBContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await db.Categories.ToListAsync();
        }
    }
}