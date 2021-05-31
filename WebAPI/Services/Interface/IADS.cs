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
    public interface IADS
    {
        Task<IEnumerable<ADS>> GetADS();
        Task<ADS> GetADSByID(string Id);
        Task<DataResults<object>> InsertADS(ADS data, string user);
        Task<DataResults<object>> UpdateADS(ADS data, string user);
        Task<DataResults<object>> DeleteADS(ADS data, string user);
    }
}
