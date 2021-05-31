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
    public class ContentServices : IContent
    {
        private readonly IConfiguration _config;
        private string conString;
        private BaseServices _servicesBase;
        public ContentServices(IConfiguration config)
        {
            _config = config;
            conString = _config.GetConnectionString("CN");
            _servicesBase = new BaseServices();
        }
        public async Task<IEnumerable<Content>> GetContent()
        {
            return await _servicesBase.GetList<Content>("Content", conString);
        }
        public async Task<Content> GetContentByID(string Id)
        {
            var results = await _servicesBase.GetById<Content>("Content", "ID", Id, conString);
            return results;
        }
        public async Task<DataResults<object>> InsertContent(Content data, string user)
        {
            _servicesBase.CommonUpdate(data, user, CommonEnum.EnumMethod.Update);
            object obj = new
            {
                data.Name,
                data.Content_CMT,
               
                CreatedBy = user,
            };
            return await _servicesBase.Insert("Content", obj, conString);
        }
        public async Task<DataResults<object>> UpdateContent(Content data, string user)
        {
            _servicesBase.CommonUpdate(data, user, CommonEnum.EnumMethod.Update);
            object obj = new
            {
                data.Name,
                data.Content_CMT,
                ModifiedDate = DateTime.Now,
                CreatedBy = user,

            };
            return await _servicesBase.Update("Content", obj, conString);
        }
        public async Task<DataResults<object>> DeleteContent(Content data, string user)
        {
            _servicesBase.CommonUpdate(data, user, CommonEnum.EnumMethod.Update);
            object obj = new
            {
                CreatedBy = user,
                ModifiedDate = DateTime.Now,
                Status = false,
            };

            return await _servicesBase.Update("Content", obj, conString, "ID", data.ID);
        }
    }
}
