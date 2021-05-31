using LIB.Base;
using LIB.BaseModels;
using LIB.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Services.Interface
{
    public interface INews
    {
        Task<IEnumerable<News>> GetNews();
        Task<News> GetNewsByID(string Id);
        Task<DataResults<object>> InsertNews(News data, string user);
        Task<DataResults<object>> UpdateNews(News data, string user);
        Task<DataResults<object>> DeleteNews(News data, string user);
    }
}
