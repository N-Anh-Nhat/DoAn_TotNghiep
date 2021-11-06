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
    public interface IProductSize
    {
        Task<IEnumerable<ProductSize>> GetProductSize();
        Task<ProductSize> GetProductSizeByID(string Id);
        Task<DataResults<object>> InsertProductSize(ProductSize data, string user);
        Task<DataResults<object>> UpdateProductSize(ProductSize data, string user);
        Task<DataResults<object>> UpdateListProductSize(List<ProductSize> data, string user);

    }
}
