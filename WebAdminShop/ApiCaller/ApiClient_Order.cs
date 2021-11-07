using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LIB.BaseModels;
using WebAPI.Models;

namespace WebAdminShop.ApiCaller
{
    public partial class ApiClient
    {
        public async Task<Orders> GetOrderById(string Id, string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Order/GetOrderById?Id=" + Id));

            var x = await GetAsync<Orders>(requestUrl, token);

            return x;
        }

        public async Task<IEnumerable<Orders>> GetOrder(string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Order/GetOrder"));

            var x = await GetAsync<IEnumerable<Orders>>(requestUrl, token);

            return x;
        }
        public async Task<Message<DataResults<object>>> InsertOrder(Orders data, string user, string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Order/InsertOrder?user=" + user));
            var x = await PostAsync<DataResults<object>, object>(requestUrl, data, token);
            return x;
        }

        public async Task<Message<DataResults<object>>> UpdateOrder(Orders data, string user, string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Order/UpdateOrder?user=" + user));
            var x = await PostAsync<DataResults<object>, Orders>(requestUrl, data, token);
            return x;
        }


    }
}
