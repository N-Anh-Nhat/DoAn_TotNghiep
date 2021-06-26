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
    public interface IProduct_detail
    {
        Task<IEnumerable<Product_Detail>> GetProduct_Detail();
        Task<Product_Detail> GetProduct_DetailByID(string Id);
        Task<DataResults<object>> InsertProduct_Detail(Product_Detail data, string user);
        Task<DataResults<object>> UpdateProduct_Detail(Product_Detail data, string user);

    }
}
