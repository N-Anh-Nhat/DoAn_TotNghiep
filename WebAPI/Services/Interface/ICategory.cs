using LIB.Base;
using LIB.BaseModels;
using LIB.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Services.Interface
{
    public interface ICategory
    {
        Task<IEnumerable<Category>> GetCategory();
        Task<Category> GetCategoryByID(string Id);
        Task<DataResults<object>> InsertCategory(Category data, string user);
    }
}
