using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LIB.BaseModels;
using WebAPI.Models;

namespace WebAdminShop.ApiCaller
{
    public partial class ApiClient
    {
        public async Task<Message<bool>> SendMail(MailContent mail, string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "SendMail/SendMailS"));

            var x = await PostAsync<bool,MailContent>(requestUrl, mail, token);

            return x;
        }

        
    }
}
