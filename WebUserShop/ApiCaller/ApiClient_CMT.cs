using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LIB.BaseModels;
using WebAPI.Models;

namespace WebUserShop.ApiCaller
{
    public partial class ApiClient
    {
        public async Task<CMT> GetCMTById(string Id, string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "CMT/GetCMTById?Id=" + Id));

            var x = await GetAsync<CMT>(requestUrl, token);

            return x;
        }

        public async Task<IEnumerable<CMT>> GetCMT(string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "CMT/GetCMT"));

            var x = await GetAsync<IEnumerable<CMT>>(requestUrl, token);

            return x;
        }
        public async Task<Message<DataResults<object>>> InsertCMT(CMT data, string user, string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "CMT/InsertCMT?user=" + user));
            var x = await PostAsync<DataResults<object>, object>(requestUrl, data, token);
            return x;
        }

        public async Task<Message<DataResults<object>>> UpdateCMT(CMT data, string user, string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "CMT/UpdateCMT?user=" + user));
            var x = await PostAsync<DataResults<object>, CMT>(requestUrl, data, token);
            return x;
        }
        public async Task<Message<DataResults<int>>> DeleteCMT(CMT data, string user, string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "CMT/DeleteCMT?user=" + user));
            var x = await PostAsync<DataResults<int>, CMT>(requestUrl, data, token);
            return x;
        }

    }
}
