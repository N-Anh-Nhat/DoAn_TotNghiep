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
    public class WishListServices : IWishList
    {
        private readonly IConfiguration _config;
        private string conString;
        private BaseServices _servicesBase;
        public WishListServices(IConfiguration config)
        {
            _config = config;
            conString = _config.GetConnectionString("CN");
            _servicesBase = new BaseServices();
        }
        public async Task<IEnumerable<WishList>> GetWishList()
        {
            return await _servicesBase.GetList<WishList>("WishList", conString);
        }
        public async Task<WishList> GetWishListByID(string Id)
        {
            var results = await _servicesBase.GetById<WishList>("WishList", "ID", Id, conString);
            return results;
        }
        public async Task<DataResults<object>> InsertWishList(WishList data, string user)
        {
            _servicesBase.CommonUpdate(data, user, CommonEnum.EnumMethod.Update);
            object obj = new
            {
                data.ID_Product,
                data.ID_User,
                CreatedBy = user,
            };
            return await _servicesBase.Insert("WishList", obj, conString);
        }
        public async Task<DataResults<object>> UpdateWishList(WishList data, string user)
        {
            object obj = new
            {
                data.Status,
                ModifiedDate = DateTime.Now,
            };
            DataResults<object> result = new DataResults<object>();
            try
            {
                using (var sqlConnection = new SqlConnection(conString))
                {
                    var db = new QueryFactory(sqlConnection, new SqlServerCompiler());
                    var results = await db.Query("WishList").WhereRaw("ID='" + data.ID + "'").UpdateAsync(obj);
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
        //public async Task<DataResults<object>> DeleteWishList(WishList data, string user)
        //{
        //    _servicesBase.CommonUpdate(data, user, CommonEnum.EnumMethod.Update);
        //    object obj = new
        //    {
        //        Status = false,
        //    };

        //    return await _servicesBase.Update("WishList", obj, conString, "ID", data.ID);
        //}
        public async Task<DataResults<int>> DeleteWishList(WishList data, string user)
        {
            var result = new DataResults<int>();
            int changed = 0;
            try
            {
                using (var sqlConnection = new SqlConnection(conString))
                {
                    sqlConnection.Open();
                    sqlConnection.Query("delete WishList where ID = '" + data.ID + "'");
                    result.Message = "succeeded";
                    result.Status = 1;
                    result.Data = changed;
                    return result;
                }
            }
            catch (Exception ex)
            {
                result.Status = -1;
                result.Message = ex.Message;
                result.Data = 0;
                return result;
            }
        }
    }
}
