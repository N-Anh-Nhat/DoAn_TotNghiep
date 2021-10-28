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
    public class UserServices : IUser
    {
        private readonly IConfiguration _config;
        private string conString;
        private BaseServices _servicesBase;
        public UserServices(IConfiguration config)
        {
            _config = config;
            conString = _config.GetConnectionString("CN");
            _servicesBase = new BaseServices();
        }
        public async Task<IEnumerable<User>> GetUser()
        {
            return await _servicesBase.GetList<User>("User", conString);
        }
        public async Task<User> GetUserByID(string Id)
        {
            var results = await _servicesBase.GetById<User>("User", "ID", Id, conString);
            return results;
        }
        public async Task<DataResults<object>> InsertUser(User data, string user)
        {
            _servicesBase.CommonUpdate(data, user, CommonEnum.EnumMethod.Update);
            object obj = new
            {
                data.UserName,
                data.Password,                
                data.Last_Name,
                data.Frist_Name,
                data.Address,
                data.Email,
                data.Phone,
                data.ID_Role,
                CreatedBy = user,
            };
            return await _servicesBase.Insert("User", obj, conString);
        }
        public async Task<DataResults<object>> UpdateUser(User data, string user)
        {
          
            object obj = new
            {
                data.UserName,
                data.Password,
                data.Last_Name,
                data.Frist_Name,
                data.Address,
                data.Email,
                data.Phone,
                data.ID_Role,
            };
            DataResults<object> result = new DataResults<object>();
            try
            {
                using (var sqlConnection = new SqlConnection(conString))
                {
                    var db = new QueryFactory(sqlConnection, new SqlServerCompiler());
                    var results = await db.Query("User").WhereRaw("ID='" + data.ID + "'").UpdateAsync(obj);
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
        //public async Task<DataResults<object>> DeleteUser(User data, string user)
        //{
        //    _servicesBase.CommonUpdate(data, user, CommonEnum.EnumMethod.Update);
        //    object obj = new
        //    {
        //        CreatedBy = user,
        //        ModifiedDate = DateTime.Now,
        //        Status = false,
        //    };

        //    return await _servicesBase.Update("User", obj, conString, "ID", data.ID);
        //}
    }
}
