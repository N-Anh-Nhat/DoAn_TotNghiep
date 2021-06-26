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
    public interface IProduct
    {
        Task<IEnumerable<Product>> GetProduct();
        Task<Product> GetProductByID(string Id);
        Task<DataResults<object>> InsertProduct(Product data, string user);
        Task<DataResults<object>> UpdateProduct(Product data, string user);
    }
}
