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
using LIB.Extensions;

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
        public async Task<IEnumerable<Order_Details>> GetOrder_Detail()
        {
            return await _servicesBase.GetList<Order_Details>("Order_Details", conString);
        }
        public async Task<IEnumerable<Order_Details>> GetOrder_DetailByID(int Id)
        {
            try
            {
                using (var sqlConnection = new SqlConnection(conString))
                {
                    var db = new QueryFactory(sqlConnection, new SqlServerCompiler());
                    var result = db.Query("Order_Details").Where("ID_Order", Id);
                    return await result.GetAsync<Order_Details>();
                }
            }
            catch (Exception ex)
            {
                
                return null;
            }
        }
        public async Task<Orders> GetIdNow()
        {
            try
            {
                using (var sqlConnection = new SqlConnection(conString))
                {
                    var db = new QueryFactory(sqlConnection, new SqlServerCompiler());
                    var result =await db.Query("Orders").OrderByDesc("ID").Limit(1).FirstOrDefaultAsync<Orders>();
                    return result;
                }
            }
            catch (Exception ex)
            {
                return new Orders();
            }
        }
        public async Task<DataResults<object>> InsertOrder_Detail(List<Order_Details> data, string user)
        {
            DataResults<object> dataResults = new DataResults<object>();
            try
            {
                using (var sqlConnection = new SqlConnection(conString))
                {
                    var db = new QueryFactory(sqlConnection, new SqlServerCompiler());
                    var res = await GetIdNow();

                    foreach (var item in data)
                    {
                        var obj = new
                        {
                            
                            item.ID_Size,
                            item.Note,
                            item.Price,
                            item.PromotionPrice,
                            item.Quality,                          
                            CreatedBy = user,
                            CreatedDate = DateTime.Now,
                            ModifiedDate = DateTime.Now,
                            ID_Order = res.ID,
                            Status = true,
                        };
                       
                        var rs = db.Query("Order_Details").Insert(obj);
                        if (rs <= 0)
                        {
                            
                            dataResults.Status = -1;
                            dataResults.Message = "failed";
                            return dataResults;
                        }
                    }
                    dataResults.Status = 1;
                    dataResults.Message = "sussces";
                }
            }
            catch (Exception ex)
            {
                dataResults.Status = -1;
                dataResults.Data = null;
                dataResults.Message = ex.Message;
            }

            return dataResults;
        }
        public async Task<DataResults<object>> UpdateOrder_Detail(Order_Details data, string user)
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
                    var results = await db.Query("Order_Details").WhereRaw("ID='" + data.ID + "'").UpdateAsync(obj);
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
        public async Task<DataResults<object>> DeleteOrder_Detail(Order_Details data, string user)
        {
            _servicesBase.CommonUpdate(data, user, CommonEnum.EnumMethod.Update);
            object obj = new
            {
                Status = false,
            };

            return await _servicesBase.Update("Order_Details", obj, conString, "ID", data.ID);
        }
    }
}
