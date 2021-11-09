using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LIB.BaseModels;
using WebAPI.Models;

namespace WebUserShop.ApiCaller
{
    public partial class ApiClient
    {
        public async Task<WishList> GetWishListById(string Id, string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "WishList/GetWishListById?Id=" + Id));

            var x = await GetAsync<WishList>(requestUrl, token);

            return x;
        }

        public async Task<IEnumerable<WishList>> GetWishList(string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "WishList/GetWishList"));

            var x = await GetAsync<IEnumerable<WishList>>(requestUrl, token);

            return x;
        }
        public async Task<Message<DataResults<object>>> InsertWishList(WishList data, string user, string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "WishList/InsertWishList?user=" + user));
            var x = await PostAsync<DataResults<object>, object>(requestUrl, data, token);
            return x;
        }

        public async Task<Message<DataResults<object>>> UpdateWishList(WishList data, string user, string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "WishList/UpdateWishList?user=" + user));
            var x = await PostAsync<DataResults<object>, WishList>(requestUrl, data, token);
            return x;
        }
        public async Task<Message<DataResults<int>>> DeleteWishList(WishList data, string user, string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "WishList/DeleteWishList?user=" + user));
            var x = await PostAsync<DataResults<int>, WishList>(requestUrl, data, token);
            return x;
        }

    }
}
