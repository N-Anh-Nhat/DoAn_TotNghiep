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
    public class ProductServices:IProduct
    {
        private readonly IConfiguration _config;
        private string conString;
        private BaseServices _servicesBase;
        public ProductServices(IConfiguration config)
        {
            _config = config;
            conString = _config.GetConnectionString("CN");
            _servicesBase = new BaseServices();
        }
        public async Task<IEnumerable<Product>> GetProduct()
        {
            return await _servicesBase.GetList<Product>("Product", conString);
        }
        public async Task<Product> GetProductByID(string Id)
        {
            var results = await _servicesBase.GetById<Product>("Product", "ID", Id, conString);
            return results;
        }
        public async Task<DataResults<object>> InsertProduct(Product data, string user)
        {
            _servicesBase.CommonUpdate(data, user, CommonEnum.EnumMethod.Update);
            object obj = new
            {
               
                data.Image,
                data.Name,
                data.Total_Quality,
                data.MoreImages,
                data.Price,
                data.PromotionPrice,
                data.Description,
                data.Detail,
                data.ID_Catelogy,
                data.Status,
                CreatedBy = user,
            };
            return await _servicesBase.Insert("Product", obj, conString);
        }
        public async Task<DataResults<object>> UpdateProduct(Product data, string user)
        {
            object obj = new
            {
                data.Image,
                data.Name,
                data.Total_Quality,
                data.MoreImages,
                data.Price,
                data.PromotionPrice,
                data.Description,
                data.ID_Catelogy,
                data.Status,
                data.Detail,
            };
            DataResults<object> result = new DataResults<object>();
            try
            {
                using (var sqlConnection = new SqlConnection(conString))
                {
                    var db = new QueryFactory(sqlConnection, new SqlServerCompiler());
                    var results = await db.Query("Product").WhereRaw("ID='" + data.ID + "'").UpdateAsync(obj);
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
