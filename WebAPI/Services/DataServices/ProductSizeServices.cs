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
    public class ProductSizeServices:IProductSize
    {
         private readonly IConfiguration _config;
        private string conString;
        private BaseServices _servicesBase;
        public ProductSizeServices(IConfiguration config)
        {
            _config = config;
            conString = _config.GetConnectionString("CN");
            _servicesBase = new BaseServices();
        }
        public async Task<IEnumerable<ProductSize>> GetProductSize()
        {
            return await _servicesBase.GetList<ProductSize>("ProductSize", conString);
        }
        public async Task<ProductSize> GetProductSizeByID(string Id)
        {
            var results = await _servicesBase.GetById<ProductSize>("ProductSize", "ID", Id, conString);
            return results;
        }
        public async Task<DataResults<object>> InsertProductSize(ProductSize data, string user)
        {
            _servicesBase.CommonUpdate(data, user, CommonEnum.EnumMethod.Update);
            object obj = new
            {
                data.ID_Product,
                Status = false,
                data.Size,
                data.Quality,
                CreatedBy = user,
            };
            return await _servicesBase.Insert("ProductSize", obj, conString);
        }
        public async Task<DataResults<object>> UpdateProductSize(ProductSize data, string user)
        {
            object obj = new
            {
                data.ID_Product,
                data.Status,
                data.Size,
                data.Quality,
            };
            DataResults<object> result = new DataResults<object>();
            try
            {
                using (var sqlConnection = new SqlConnection(conString))
                {
                    var db = new QueryFactory(sqlConnection, new SqlServerCompiler());
                    var results = await db.Query("ProductSize").WhereRaw("ID='" + data.ID + "'").UpdateAsync(obj);
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
        public async Task<DataResults<object>> UpdateListProductSize(List<ProductSize> data, string user)
        {
           
            DataResults<object> result = new DataResults<object>();
            try
            {
                using (var sqlConnection = new SqlConnection(conString))
                {
                    var db = new QueryFactory(sqlConnection, new SqlServerCompiler());
                    foreach (var item in data)
                    {
                        var obj = new
                        {                          
                            item.Quality,                                                      
                            ModifiedDate = DateTime.Now,                                                     
                        };

                        var results = await db.Query("ProductSize").WhereRaw("ID='" + item.ID + "'").UpdateAsync(obj);
                        if (results <= 0)
                        {

                            result.Status = -1;
                            result.Message = "failed";
                            return result;
                        }
                    }
                    result.Status = 1;
                    result.Message = "sussces";
                    
                    
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
