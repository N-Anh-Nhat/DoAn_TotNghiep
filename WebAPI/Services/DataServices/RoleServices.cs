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
    public class RoleServices : IRole
    {
        private readonly IConfiguration _config;
        private string conString;
        private BaseServices _servicesBase;
        public RoleServices(IConfiguration config)
        {
            _config = config;
            conString = _config.GetConnectionString("CN");
            _servicesBase = new BaseServices();
        }
        public async Task<IEnumerable<Role>> GetRole()
        {
            return await _servicesBase.GetList<Role>("Role", conString);
        }
        public async Task<Role> GetRoleByID(string Id)
        {
            var results = await _servicesBase.GetById<Role>("Role", "ID", Id, conString);
            return results;
        }
        public async Task<DataResults<object>> InsertRole(Role data, string user)
        {
            _servicesBase.CommonUpdate(data, user, CommonEnum.EnumMethod.Update);
            object obj = new
            {
                data.NameRole,
                data.Detail
                
            };
            return await _servicesBase.Insert("Role", obj, conString);
        }
        public async Task<DataResults<object>> UpdateRole(Role data, string user)
        {
            object obj = new
            {
                data.NameRole,
                data.Detail
            };
            DataResults<object> result = new DataResults<object>();
            try
            {
                using (var sqlConnection = new SqlConnection(conString))
                {
                    var db = new QueryFactory(sqlConnection, new SqlServerCompiler());
                    var results = await db.Query("Role").WhereRaw("ID='" + data.ID + "'").UpdateAsync(obj);
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
        public async Task<DataResults<object>> DeleteRole(Role data, string user)
        {
            _servicesBase.CommonUpdate(data, user, CommonEnum.EnumMethod.Update);
            object obj = new
            {              
                Status = false,
            };

            return await _servicesBase.Update("Role", obj, conString, "ID", data.ID);
        }
    }
}

