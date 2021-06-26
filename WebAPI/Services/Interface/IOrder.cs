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
    public interface IOrder
    {
        Task<IEnumerable<Order>> GetOrder();
        Task<Order> GetOrderByID(string Id);
        Task<DataResults<object>> InsertOrder(Order data, string user);
        Task<DataResults<object>> UpdateOrder(Order data, string user);
        Task<DataResults<object>> DeleteOrder(Order data, string user);
    }
}
