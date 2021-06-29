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
    public class Product_DetailServices:IProduct_detail
    {
         private readonly IConfiguration _config;
        private string conString;
        private BaseServices _servicesBase;
        public Product_DetailServices(IConfiguration config)
        {
            _config = config;
            conString = _config.GetConnectionString("CN");
            _servicesBase = new BaseServices();
        }
        public async Task<IEnumerable<Product_Detail>> GetProduct_Detail()
        {
            return await _servicesBase.GetList<Product_Detail>("Product_Detail", conString);
        }
        public async Task<Product_Detail> GetProduct_DetailByID(string Id)
        {
            var results = await _servicesBase.GetById<Product_Detail>("Product_Detail", "ID", Id, conString);
            return results;
        }
        public async Task<DataResults<object>> InsertProduct_Detail(Product_Detail data, string user)
        {
            _servicesBase.CommonUpdate(data, user, CommonEnum.EnumMethod.Update);
            object obj = new
            {
                data.Size,
                data.Quality,
                CreatedBy = user,
            };
            return await _servicesBase.Insert("Product_Detail", obj, conString);
        }
        public async Task<DataResults<object>> UpdateProduct_Detail(Product_Detail data, string user)
        {
            object obj = new
            {
                data.Size,
                data.Quality,
            };
            DataResults<object> result = new DataResults<object>();
            try
            {
                using (var sqlConnection = new SqlConnection(conString))
                {
                    var db = new QueryFactory(sqlConnection, new SqlServerCompiler());
                    var results = await db.Query("Product_Detail").WhereRaw("ID='" + data.ID + "'").UpdateAsync(obj);
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
        
    }
}
