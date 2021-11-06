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
        Task<IEnumerable<Order_Details>> GetOrder_Detail();
        Task<Order_Details> GetOrder_DetailByID(string Id);
        Task<DataResults<object>> InsertOrder_Detail(List<Order_Details> data, string user);
        Task<DataResults<object>> UpdateOrder_Detail(Order_Details data, string user);
        Task<DataResults<object>> DeleteOrder_Detail(Order_Details data, string user);   
    }
}
