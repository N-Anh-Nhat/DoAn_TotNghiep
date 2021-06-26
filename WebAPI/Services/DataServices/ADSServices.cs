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
    public class ADSServices : IADS
    {
        private readonly IConfiguration _config;
        private string conString;
        private BaseServices _servicesBase;
        public ADSServices(IConfiguration config)
        {
            _config = config;
            conString = _config.GetConnectionString("CN");
            _servicesBase = new BaseServices();
        }
        public async Task<IEnumerable<ADS>> GetADS()
        {
            return await _servicesBase.GetList<ADS>("ADS", conString);
        }
        public async Task<ADS> GetADSByID(string Id)
        {
            var results = await _servicesBase.GetById<ADS>("ADS", "ID", Id, conString);
            return results;
        }
        public async Task<DataResults<object>> InsertADS(ADS data, string user)
        {
            _servicesBase.CommonUpdate(data, user, CommonEnum.EnumMethod.Update);
            object obj = new
            {
                data.Name_ADS,
                data.Content_ADS,
                data.Thoi_Han,
                data.Image,
                CreatedBy = user,
            };
            return await _servicesBase.Insert("ADS", obj, conString);
        }
        public async Task<DataResults<object>> UpdateADS(ADS data, string user)
        {
            _servicesBase.CommonUpdate(data, user, CommonEnum.EnumMethod.Update);
            object obj = new
            {
                data.Name_ADS,
                data.Content_ADS,
                data.Thoi_Han,
                data.Image,
            };
            DataResults<object> result = new DataResults<object>();
            try
            {
                using (var sqlConnection = new SqlConnection(conString))
                {
                    var db = new QueryFactory(sqlConnection, new SqlServerCompiler());
                    var results = await db.Query("CMT").WhereRaw("ID='" + data.ID + "'").UpdateAsync(obj);
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
        public async Task<DataResults<object>> DeleteADS(ADS data, string user)
        {
            _servicesBase.CommonUpdate(data, user, CommonEnum.EnumMethod.Update);
            object obj = new
            {
                CreatedBy = user,
                ModifiedDate = DateTime.Now,
                Status = false,
            };

            return await _servicesBase.Update("ADS", obj, conString, "ID", data.ID);
        }
    }
}
