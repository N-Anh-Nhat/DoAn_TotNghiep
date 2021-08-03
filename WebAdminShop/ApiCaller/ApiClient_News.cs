using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LIB.BaseModels;
using WebAPI.Models;

namespace WebAdminShop.ApiCaller
{
    public partial class ApiClient
    {
        public async Task<News> GetNewsById(string Id, string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "News/GetNewsById?Id=" + Id));

            var x = await GetAsync<News>(requestUrl, token);

            return x;
        }

        public async Task<IEnumerable<News>> GetNews(string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "News/GetNews"));

            var x = await GetAsync<IEnumerable<News>>(requestUrl, token);

            return x;
        }
        public async Task<Message<DataResults<object>>> InsertNews(News data, string user, string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "News/InsertNews?user=" + user));
            var x = await PostAsync<DataResults<object>, object>(requestUrl, data, token);
            return x;
        }

        public async Task<Message<DataResults<object>>> UpdateNews(News data, string user, string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "News/UpdateNews?user=" + user));
            var x = await PostAsync<DataResults<object>, News>(requestUrl, data, token);
            return x;
        }


    }
}
