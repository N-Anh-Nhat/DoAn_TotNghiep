using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LIB.BaseModels;
using WebAPI.Models;

namespace WebUserShop.ApiCaller
{
    public partial class ApiClient
    {
        public async Task<Feedback> GetFeedbackById(string Id, string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Feedback/GetFeedbackById?Id=" + Id));

            var x = await GetAsync<Feedback>(requestUrl, token);

            return x;
        }

        public async Task<IEnumerable<Feedback>> GetFeedback(string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Feedback/GetFeedback"));

            var x = await GetAsync<IEnumerable<Feedback>>(requestUrl, token);

            return x;
        }
        public async Task<Message<DataResults<object>>> InsertFeedback(Feedback data, string user, string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Feedback/InsertsFeedback?user=" + user));
            var x = await PostAsync<DataResults<object>, object>(requestUrl, data, token);
            return x;
        }

        public async Task<Message<DataResults<object>>> UpdateFeedback(Feedback data, string user, string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Feedback/UpdateFeedback?user=" + user));
            var x = await PostAsync<DataResults<object>, Feedback>(requestUrl, data, token);
            return x;
        }


    }
}
