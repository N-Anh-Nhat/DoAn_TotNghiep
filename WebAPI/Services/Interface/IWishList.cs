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
    public interface IWishList
    {
        Task<IEnumerable<WishList>> GetWishList();
        Task<WishList> GetWishListByID(string Id);
        Task<DataResults<object>> InsertWishList(WishList data, string user);
        Task<DataResults<object>> UpdateWishList(WishList data, string user);
        Task<DataResults<int>> DeleteWishList(WishList data, string user);
    }
}
