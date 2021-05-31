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
    public interface IContent
    {
        Task<IEnumerable<Content>> GetContent();
        Task<Content> GetContentByID(string Id);
        Task<DataResults<object>> InsertContent(Content data, string user);
        Task<DataResults<object>> UpdateContent(Content data, string user);
        Task<DataResults<object>> DeleteContent(Content data, string user);
    }
}
