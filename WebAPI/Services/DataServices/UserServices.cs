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
        public async Task<User> GetUserByID(int Id)
        {
            var results = await _servicesBase.GetById<User>("User", "ID", Id.ToString(), conString);
            return results;
        }
        public async Task<DataResults<object>> InsertUser(User data, string user)
        {
            _servicesBase.CommonUpdate(data, user, CommonEnum.EnumMethod.Update);
            var pas = Security.TextToMD5(data.Password);
            object obj = new
            {
                data.UserName,
                Password = pas,                
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
                data.Password ,
                data.UserName,
                data.Last_Name,
                data.Frist_Name,
                data.Address,
                data.Email,
                data.Phone,
                ModifiedDate = DateTime.Now,
                data.ID_Role,
                data.Status,
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
                result.Data = data;
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
        public async Task<DataResults<object>> CheckLogin(string usermame, string password)
        {
            DataResults<object> returns = new DataResults<object>();

            try
            {
                using (var sqlConnection = new SqlConnection(conString))
                {
                    var db = new QueryFactory(sqlConnection, new SqlServerCompiler());

                    string Pw = Security.TextToMD5(password);

                    var rs = await db.Query("User").Where("UserName",usermame).Where("Password",Pw).Where("ID_Role",1).FirstOrDefaultAsync<User>();
                        

                    if (rs != null)
                    {
                        returns.Message = "success";
                        returns.Status = 1;
                        rs.Password = null;
                        returns.Data = rs;
                        return returns;
                    }

                    returns.Message = "Tài khoản hoặc mật khẩu không đúng";
                    returns.Status = -1;
                    return returns;
                }
            }
            catch (Exception ex)
            {
                
                returns.Message = "Đăng nhập lỗi";
                returns.Status = -1;
                return returns;
            }
        }
    }
}
