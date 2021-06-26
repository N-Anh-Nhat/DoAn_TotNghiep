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
    public interface IOder_detail
    {
        Task<IEnumerable<Order_Detail>> GetOrder_Detail();
        Task<Order_Detail> GetOrder_DetailByID(string Id);
        Task<DataResults<object>> InsertOrder_Detail(Order_Detail data, string user);
        Task<DataResults<object>> UpdateOrder_Detail(Order_Detail data, string user);
        Task<DataResults<object>> DeleteOrder_Detail(Order_Detail data, string user);   
    }
}
