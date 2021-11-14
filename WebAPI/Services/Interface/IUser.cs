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
    public interface IUser
    {
        Task<IEnumerable<User>> GetUser();
        Task<User> GetUserByID(int Id);
        Task<DataResults<object>> InsertUser(User data, string user);
        Task<DataResults<object>> UpdateUser(User data, string user);
        Task<DataResults<object>> CheckLogin(string usermame, string password);
    }
}
