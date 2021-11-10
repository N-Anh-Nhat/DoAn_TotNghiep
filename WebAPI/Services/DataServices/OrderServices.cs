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
                CreatedDate = DateTime.Now.ToString("yyyy-MM-dd"),
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
                data.Status,
                ModifiedDate = DateTime.Now,
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
           

            return await _servicesBase.Delete("Orders", obj, conString, "ID", data.ID);
        }
        public async Task<IEnumerable<object>> ReportOrder(int pyear, string user)
        {
           
           
            try
            {
                using (var sqlConnection = new SqlConnection(conString))
                {
                    var db = new QueryFactory(sqlConnection, new SqlServerCompiler());
                    var results = db.Query().SelectRaw("Product.Name as SanPham, Category.Name as Loai, COUNT(Order_Details.Quality) as Soluong,CAST(Orders.ModifiedDate AS DATE) as Ngayduyet,Order_Details.PromotionPrice,Order_Details.Price")
                        .From("Orders")
                        .GroupByRaw("Product.Name, Category.Name,CAST(Orders.ModifiedDate AS DATE),Order_Details.PromotionPrice,Order_Details.Price")
                        .OrderByRaw("CAST(Orders.ModifiedDate AS DATE)")
                        .Where("Orders.Status","true")
                        .WhereDatePart("year", "Orders.ModifiedDate",pyear)
                        .Join("Order_Details", "Order_Details.ID_Order", "Orders.ID")
                        .Join("Product", "Product.ID", "Order_Details.ID_Product")
                        .Join("Category", "Category.ID", "Product.ID_Catelogy");
                        
                        
                    return await results.GetAsync<object>();
                }
               
            }
            catch (Exception e)
            {
                var mess = e;
                return null;
               
            }
           
        }
    }
}
