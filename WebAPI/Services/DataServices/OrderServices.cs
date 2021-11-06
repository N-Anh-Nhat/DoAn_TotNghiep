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
    public class OrderServices:IOrder
    {
        private readonly IConfiguration _config;
        private string conString;
        private BaseServices _servicesBase;
        public OrderServices(IConfiguration config)
        {
            _config = config;
            conString = _config.GetConnectionString("CN");
            _servicesBase = new BaseServices();
        }
        public async Task<IEnumerable<Orders>> GetOrder()
        {
            return await _servicesBase.GetList<Orders>("Orders", conString);
        }
        public async Task<Orders> GetOrderByID(string Id)
        {
            var results = await _servicesBase.GetById<Orders>("Orders", "ID", Id, conString);
            return results;
        }
        public async Task<DataResults<object>> InsertOrder(Orders data, string user)
        {
            _servicesBase.CommonUpdate(data, user, CommonEnum.EnumMethod.Update);
            object obj = new
            {
                data.Name_order,
                data.Type_ship,
                data.Address,
                data.Email,
                data.Phone,
                data.Note,
                data.ID_User,
                data.ToTal_Money,
                CreatedBy = user,
                CreatedDate = DateTime.Now,
                Status = false,
            };
            return await _servicesBase.Insert("Orders", obj, conString);
        }
        public async Task<DataResults<object>> UpdateOrder(Orders data, string user)
        {
            object obj = new
            {
                data.Name_order,
                data.Type_ship,
                data.ToTal_Money,
            };
            DataResults<object> result = new DataResults<object>();
            try
            {
                using (var sqlConnection = new SqlConnection(conString))
                {
                    var db = new QueryFactory(sqlConnection, new SqlServerCompiler());
                    var results = await db.Query("Orders").WhereRaw("ID='" + data.ID + "'").UpdateAsync(obj);
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
        public async Task<DataResults<object>> DeleteOrder(Orders data, string user)
        {
            _servicesBase.CommonUpdate(data, user, CommonEnum.EnumMethod.Update);
            object obj = new
            {
                Status = false,
            };

            return await _servicesBase.Update("Orders", obj, conString, "ID", data.ID);
        }
    }
}
