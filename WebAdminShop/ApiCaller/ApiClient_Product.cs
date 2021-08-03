using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LIB.BaseModels;
using WebAPI.Models;

namespace WebAdminShop.ApiCaller
{
    public partial class ApiClient
    {
        public async Task<Product> GetProductById(string Id, string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Product/GetProductById?Id=" + Id));

            var x = await GetAsync<Product>(requestUrl, token);

            return x;
        }

        public async Task<IEnumerable<Product>> GetProduct(string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Product/GetProduct"));

            var x = await GetAsync<IEnumerable<Product>>(requestUrl, token);

            return x;
        }
        public async Task<Message<DataResults<object>>> InsertProduct(Product data, string user, string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Product/InsertProduct?user=" + user));
            var x = await PostAsync<DataResults<object>, object>(requestUrl, data, token);
            return x;
        }

        public async Task<Message<DataResults<object>>> UpdateProduct(Product data, string user, string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Product/UpdateProduct?user=" + user));
            var x = await PostAsync<DataResults<object>, Product>(requestUrl, data, token);
            return x;
        }


    }
}
