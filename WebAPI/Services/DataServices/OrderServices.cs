﻿using Dapper;
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
        public async Task<IEnumerable<Order>> GetOrder()
        {
            return await _servicesBase.GetList<Order>("Order", conString);
        }
        public async Task<Order> GetOrderByID(string Id)
        {
            var results = await _servicesBase.GetById<Order>("Order", "ID", Id, conString);
            return results;
        }
        public async Task<DataResults<object>> InsertOrder(Order data, string user)
        {
            _servicesBase.CommonUpdate(data, user, CommonEnum.EnumMethod.Update);
            object obj = new
            {
                data.Name_order,
                data.Type_ship,
                CreatedBy = user,
            };
            return await _servicesBase.Insert("Order", obj, conString);
        }
        public async Task<DataResults<object>> UpdateOrder(Order data, string user)
        {
            object obj = new
            {
                data.Name_order,
                data.Type_ship,
            };
            DataResults<object> result = new DataResults<object>();
            try
            {
                using (var sqlConnection = new SqlConnection(conString))
                {
                    var db = new QueryFactory(sqlConnection, new SqlServerCompiler());
                    var results = await db.Query("Feedback").WhereRaw("ID='" + data.ID + "'").UpdateAsync(obj);
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
        public async Task<DataResults<object>> DeleteOrder(Order data, string user)
        {
            _servicesBase.CommonUpdate(data, user, CommonEnum.EnumMethod.Update);
            object obj = new
            {
                Status = false,
            };

            return await _servicesBase.Update("Order", obj, conString, "ID", data.ID);
        }
    }
}
