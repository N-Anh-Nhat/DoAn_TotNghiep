using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LIB.BaseModels;
using WebAPI.Models;

namespace WebUserShop.ApiCaller
{
    public partial class ApiClient
    {
        public async Task<ProductSize> GetProductSizeById(string Id, string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "ProductSize/GetProductSizeById?Id=" + Id));

            var x = await GetAsync<ProductSize>(requestUrl, token);

            return x;
        }

        public async Task<IEnumerable<ProductSize>> GetProductSize(string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "ProductSize/GetProductSize"));

            var x = await GetAsync<IEnumerable<ProductSize>>(requestUrl, token);

            return x;
        }
        public async Task<Message<DataResults<object>>> InsertProductSize(ProductSize data, string user, string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "ProductSize/InsertProductSize?user=" + user));
            var x = await PostAsync<DataResults<object>, object>(requestUrl, data, token);
            return x;
        }

        public async Task<Message<DataResults<object>>> UpdateProductSize(ProductSize data, string user, string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "ProductSize/UpdateProductSize?user=" + user));
            var x = await PostAsync<DataResults<object>, ProductSize>(requestUrl, data, token);
            return x;
        }


    }
}
