﻿using Dapper;
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
    public class CategoryServices : ICategory
    {
        private readonly IConfiguration _config;
        private string conString;
        private BaseServices _servicesBase;
        public CategoryServices(IConfiguration config)
        {
            _config = config;
            conString = _config.GetConnectionString("CN");
            _servicesBase = new BaseServices();
        }
        public async Task<IEnumerable<Category>>GetCategory()
        {
            return await _servicesBase.GetList<Category>("Category", conString);
        }
        public async Task<Category> GetCategoryByID(string Id)
        {
            var results = await _servicesBase.GetById<Category>("Category", "ID", Id, conString);
            return results;
        }
        public async Task<DataResults<object>> InsertCategory(Category data, string user)
        {
            _servicesBase.CommonUpdate(data, user, CommonEnum.EnumMethod.Update);
            object obj = new
            {
                data.Name,
                data.Image,
                data.Detail,
                CreatedBy = user,
            };
            return await _servicesBase.Insert("Category", obj, conString);
        }
    }
}
