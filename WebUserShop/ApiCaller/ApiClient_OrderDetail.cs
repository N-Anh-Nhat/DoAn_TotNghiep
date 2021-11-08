using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LIB.BaseModels;
using WebAPI.Models;

namespace WebUserShop.ApiCaller
{
    public partial class ApiClient
    {
        public async Task<IEnumerable<Order_Details>> GetOrder_detailById(int Id, string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Order_Detail/GetOrder_DetailById?Id=" + Id));

            var x = await GetAsync<IEnumerable<Order_Details>>(requestUrl, token);

            return x;
        }

        public async Task<IEnumerable<Order_Details>> GetOrder_Detail(string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Order_Detail/GetOrder_Detail"));

            var x = await GetAsync<IEnumerable<Order_Details>>(requestUrl, token);

            return x;
        }
        public async Task<Message<DataResults<object>>> InsertOrder_Detail(List<Order_Details> data, string user, string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Order_Detail/InsertOrder_Detail?user=" + user));
            var x = await PostAsync<DataResults<object>, object>(requestUrl, data, token);
            return x;
        }

        public async Task<Message<DataResults<object>>> UpdateOrder_Detail(Order_Details data, string user, string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Order_Detail/UpdateOrder_Detail?user=" + user));
            var x = await PostAsync<DataResults<object>, Order_Details>(requestUrl, data, token);
            return x;
        }


    }
}
