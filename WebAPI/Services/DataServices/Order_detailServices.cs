using Dapper;
using Microsoft.Extensions.Configuration;
using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Services.Interface;
using LIB.Base;
using LIB.BaseModels;
using LIB.Common;

namespace WebAPI.Services.DataServices
{
    public class Order_DetailServices:IOder_detail
    {
        private readonly IConfiguration _config;
        private string conString;
        private BaseServices _servicesBase;
        public Order_DetailServices(IConfiguration config)
        {
            _config = config;
            conString = _config.GetConnectionString("CN");
            _servicesBase = new BaseServices();
        }
        public async Task<IEnumerable<Order_Detail>> GetOrder_Detail()
        {
            return await _servicesBase.GetList<Order_Detail>("Order_Detail", conString);
        }
        public async Task<Order_Detail> GetOrder_DetailByID(string Id)
        {
            var results = await _servicesBase.GetById<Order_Detail>("Order_Detail", "ID", Id, conString);
            return results;
        }
        public async Task<DataResults<object>> InsertOrder_Detail(Order_Detail data, string user)
        {
            _servicesBase.CommonUpdate(data, user, CommonEnum.EnumMethod.Update);
            object obj = new
            {
                data.Quality,
                data.PromotionPrice,
                 CreatedBy = user,
            };
            return await _servicesBase.Insert("Order_Detail", obj, conString);
        }
        public async Task<DataResults<object>> UpdateOrder_Detail(Order_Detail data, string user)
        {
            object obj = new
            {
                data.Quality,
                data.PromotionPrice
            };
            DataResults<object> result = new DataResults<object>();
            try
            {
                using (var sqlConnection = new SqlConnection(conString))
                {
                    var db = new QueryFactory(sqlConnection, new SqlServerCompiler());
                    var results = await db.Query("Order_Detail").WhereRaw("ID='" + data.ID + "'").UpdateAsync(obj);
                    if (results == 1)
                    {
                        result.Message = "successed";
                        result.Status = 1;
                        result.Data = data;
                    }
                    else
                    {
                        result.Message = "failed";
                        result.Status = -1;
                        result.Data = data;
                    }
                }
                return result;
            }
            catch (Exception e)
            {

                result.Message = e.Message;
                result.Status = -1;
                result.Data = data; ;
            }
            return result;
        }
        public async Task<DataResults<object>> DeleteOrder_Detail(Order_Detail data, string user)
        {
            _servicesBase.CommonUpdate(data, user, CommonEnum.EnumMethod.Update);
            object obj = new
            {
                Status = false,
            };

            return await _servicesBase.Update("Order_Detail", obj, conString, "ID", data.ID);
        }
    }
}
