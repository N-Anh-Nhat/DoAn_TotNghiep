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
    public class NewsServices : INews
    {
        private readonly IConfiguration _config;
        private string conString;
        private BaseServices _servicesBase;
        public NewsServices(IConfiguration config)
        {
            _config = config;
            conString = _config.GetConnectionString("CN");
            _servicesBase = new BaseServices();
        }
        public async Task<IEnumerable<News>> GetNews()
        {
            return await _servicesBase.GetList<News>("News", conString);
        }
        public async Task<News> GetNewsByID(string Id)
        {
            var results = await _servicesBase.GetById<News>("News", "ID", Id, conString);
            return results;
        }
        public async Task<DataResults<object>> InsertNews(News data, string user)
        {
            _servicesBase.CommonUpdate(data, user, CommonEnum.EnumMethod.Update);
            object obj = new
            {
                data.Name,
                data.Image,

                CreatedBy = user,
            };
            return await _servicesBase.Insert("News", obj, conString);
        }
        public async Task<DataResults<object>> UpdateNews(News data, string user)
        {
            _servicesBase.CommonUpdate(data, user, CommonEnum.EnumMethod.Update);
            object obj = new
            {
                data.Name,
                data.Image,
                data.Content_news,
                CreatedBy = user,

            };
            return await _servicesBase.Update("News", obj, conString);
        }
        public async Task<DataResults<object>> DeleteNews(News data, string user)
        {
            _servicesBase.CommonUpdate(data, user, CommonEnum.EnumMethod.Update);
            object obj = new
            {
                CreatedBy = user,
                ModifiedDate = DateTime.Now,
                Status = false,
            };

            return await _servicesBase.Update("News", obj, conString, "ID", data.ID);
        }
    }
}

