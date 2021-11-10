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
        Task<IEnumerable<Orders>> GetOrder();
        Task<Orders> GetOrderByID(string Id);
        Task<DataResults<object>> InsertOrder(Orders data, string user);
        Task<DataResults<object>> UpdateOrder(Orders data, string user);
        Task<DataResults<object>> DeleteOrder(Orders data, string user);
        Task<IEnumerable<object>> ReportOrder(int pyear, string user);
    }
}
