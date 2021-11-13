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
    public class CMTServices:ICMT
    {
        private readonly IConfiguration _config;
        private string conString;
        private BaseServices _servicesBase;
        public CMTServices(IConfiguration config)
        {
            _config = config;
            conString = _config.GetConnectionString("CN");
            _servicesBase = new BaseServices();
        }
        public async Task<IEnumerable<CMT>> GetCMT()
        {
            return await _servicesBase.GetList<CMT>("CMT", conString);
        }
        public async Task<CMT> GetCMTByID(string Id)
        {
            var results = await _servicesBase.GetById<CMT>("CMT", "ID", Id, conString);
            return results;
        }
        public async Task<DataResults<object>> InsertCMT(CMT data, string user)
        {
            _servicesBase.CommonUpdate(data, user, CommonEnum.EnumMethod.Update);
            object obj = new
            {
                data.Content_CMT,
                data.ID_Product,
                data.ID_User,
                CreatedBy = user,
            };
            return await _servicesBase.Insert("CMT", obj, conString);
        }
        public async Task<DataResults<object>> UpdateCMT(CMT data, string user)
        {
            _servicesBase.CommonUpdate(data, user, CommonEnum.EnumMethod.Update);
            object obj = new
            {
                data.Content_CMT,
                data.Name,
            };
            DataResults<object> result = new DataResults<object>();
            try
            {
                using(var sqlConnection =new SqlConnection(conString))
                {
                    var db = new QueryFactory(sqlConnection, new SqlServerCompiler());
                    var results = await db.Query("CMT").WhereRaw("ID='" + data.ID + "'").UpdateAsync(obj);
                    if (results==1)
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
        public async Task<DataResults<int>> DeleteCMT(CMT data, string user)
        {
            var result = new DataResults<int>();
            int changed = 0;
            try
            {
                using (var sqlConnection = new SqlConnection(conString))
                {
                    sqlConnection.Open();
                    sqlConnection.Query("delete CMT where ID = '" + data.ID + "'");
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
