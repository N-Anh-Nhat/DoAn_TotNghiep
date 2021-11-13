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
    public interface ICMT
    {
        Task<IEnumerable<CMT>> GetCMT();
        Task<CMT> GetCMTByID(string Id);
        Task<DataResults<object>> InsertCMT(CMT data, string user);
        Task<DataResults<object>> UpdateCMT(CMT data, string user);
        Task<DataResults<int>> DeleteCMT(CMT data, string user);
    }
}
