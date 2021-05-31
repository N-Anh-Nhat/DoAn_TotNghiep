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
    public interface IRole
    {
        Task<IEnumerable<Role>> GetRole();
        Task<Role> GetRoleByID(string Id);
        Task<DataResults<object>> InsertRole(Role data, string user);
        Task<DataResults<object>> UpdateRole(Role data, string user);
        Task<DataResults<object>> DeleteRole(Role data, string user);
    }
}
