using LIB.Base;
using LIB.BaseModels;
using LIB.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Services.Interface
{
    public interface ISendMailServices
    {
        Task SendEmailAsync(string email, string subject, string htmlMessage);
        Task<bool> SendMail(MailContent mailContent);
    }
}
