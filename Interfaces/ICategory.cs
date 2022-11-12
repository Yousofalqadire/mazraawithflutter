using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mazaare3.Models;

namespace Mazaare3.Interfaces
{
    public interface ICategory
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();
    }
}