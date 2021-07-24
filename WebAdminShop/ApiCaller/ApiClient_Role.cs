using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LIB.BaseModels;
using WebAPI.Models;

namespace WebAdminShop.ApiCaller
{
    public partial class ApiClient
    {
        public async Task<Role> GetRoleById(string Id, string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Role/GetRoleById?Id=" + Id));

            var x = await GetAsync<Role>(requestUrl, token);

            return x;
        }

        public async Task<IEnumerable<Role>> GetRole(string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Role/GetRole"));

            var x = await GetAsync<IEnumerable<Role>>(requestUrl, token);

            return x;
        }
        public async Task<Message<DataResults<object>>> InsertRole(Role data, string user, string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Role/InsertRole?user=" + user));
            var x = await PostAsync<DataResults<object>, object>(requestUrl, data, token);
            return x;
        }

        public async Task<Message<DataResults<object>>> UpdateRole(Role data, string user, string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Role/UpdateRole?user=" + user));
            var x = await PostAsync<DataResults<object>, Role>(requestUrl, data, token);
            return x;
        }


    }
}
