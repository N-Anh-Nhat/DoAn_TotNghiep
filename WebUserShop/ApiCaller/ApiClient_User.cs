using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LIB.BaseModels;
using WebAPI.Models;

namespace WebUserShop.ApiCaller
{
    public partial class ApiClient
    {
        public async Task<User> GetUserById(string Id, string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "User/GetUserById?Id=" + Id));

            var x = await GetAsync<User>(requestUrl, token);

            return x;
        }

        public async Task<IEnumerable<User>> GetUser(string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "User/GetUser"));

            var x = await GetAsync<IEnumerable<User>>(requestUrl, token);

            return x;
        }
        public async Task<Message<DataResults<object>>> InsertUser(User data, string user, string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "User/InsertsUser?user=" + user));
            var x = await PostAsync<DataResults<object>, object>(requestUrl, data, token);
            return x;
        }

        public async Task<Message<DataResults<object>>> UpdateUser(User data, string user, string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "User/UpdateUser?user=" + user));
            var x = await PostAsync<DataResults<object>, User>(requestUrl, data, token);
            return x;
        }


    }
}
