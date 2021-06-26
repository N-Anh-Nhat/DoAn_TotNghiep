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
                CreatedBy = user,

            };
            return await _servicesBase.Update("ADS", obj, conString);
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
