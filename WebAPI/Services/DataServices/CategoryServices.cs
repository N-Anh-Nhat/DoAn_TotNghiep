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

namespace WebAPI.Services.DataServices
{
    public class CategoryServices : ICategory
    {
        private readonly IConfiguration _config;
        private string conString;

        public CategoryServices(IConfiguration config)
        {
            _config = config;
            conString = _config.GetConnectionString("CN");
        }
        public async Task<IEnumerable<Category>>GetCategory()
        {
            using(var sqlConnection =  new SqlConnection(conString))
            {
                var db = new QueryFactory(sqlConnection, new SqlServerCompiler());

                var results = db.Query().From("Category");
                return await results.GetAsync<Category>();
            }
        }
    }
}
