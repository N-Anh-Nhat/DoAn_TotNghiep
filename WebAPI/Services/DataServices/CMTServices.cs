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
                data.Name,
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
                CreatedBy = user,

            };
            return await _servicesBase.Update("CMT", obj, conString);
        }
        public async Task<DataResults<object>> DeleteCMT(CMT data, string user)
        {
            _servicesBase.CommonUpdate(data, user, CommonEnum.EnumMethod.Update);
            object obj = new
            {
                CreatedBy = user,
                ModifiedDate = DateTime.Now,
                Status = false,
            };

            return await _servicesBase.Update("CMT", obj, conString, "ID", data.ID);
        }
    }
}
