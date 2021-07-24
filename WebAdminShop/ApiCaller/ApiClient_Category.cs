using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LIB.BaseModels;
using WebAPI.Models;

namespace WebAdminShop.ApiCaller
{
    public partial class ApiClient
    {
        public async Task<Category> GetCategoryById(string Id, string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Category/GetCategoryById?Id=" + Id));

            var x = await GetAsync<Category>(requestUrl, token);

            return x;
        }

        public async Task<IEnumerable<Category>> GetCategory(string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Category/GetCategory"));

            var x = await GetAsync<IEnumerable<Category>>(requestUrl, token);

            return x;
        }
        public async Task<Message<DataResults<object>>> InsertCategory(Category data, string user, string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Category/InsertCategory?user=" + user));
            var x = await PostAsync<DataResults<object>, object>(requestUrl, data, token);
            return x;
        }

        public async Task<Message<DataResults<object>>> UpdateCategory(Category data, string user, string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Category/UpdateCategory?user=" + user));
            var x = await PostAsync<DataResults<object>, Category>(requestUrl, data, token);
            return x;
        }


    }
}
