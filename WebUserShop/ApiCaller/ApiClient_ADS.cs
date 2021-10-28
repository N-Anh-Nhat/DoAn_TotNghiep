using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LIB.BaseModels;
using WebAPI.Models;

namespace WebUserShop.ApiCaller
{
    public partial class ApiClient
    {
        public async Task<ADS> GetADSById(string Id, string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "ADS/GetADSById?Id=" + Id));

            var x = await GetAsync<ADS>(requestUrl, token);

            return x;
        }

        public async Task<IEnumerable<ADS>> GetADS(string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "ADS/GetADS"));

            var x = await GetAsync<IEnumerable<ADS>>(requestUrl, token);

            return x;
        }
        public async Task<Message<DataResults<object>>> InsertADS(ADS data, string user, string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "ADS/InsertADS?user=" + user));
            var x = await PostAsync<DataResults<object>, object>(requestUrl, data, token);
            return x;
        }

        public async Task<Message<DataResults<object>>> UpdateADS(ADS data, string user, string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "ADS/UpdateADS?user=" + user));
            var x = await PostAsync<DataResults<object>, ADS>(requestUrl, data, token);
            return x;
        }


    }
}
