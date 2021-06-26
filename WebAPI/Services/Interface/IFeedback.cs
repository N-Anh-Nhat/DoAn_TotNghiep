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
    public interface IFeedback
    {
        Task<IEnumerable<Feedback>> GetFeedback();
        Task<Feedback> GetFeedbackByID(string Id);
        Task<DataResults<object>> InsertFeedback(Feedback data, string user);
        Task<DataResults<object>> UpdateFeedback(Feedback data, string user);
        Task<DataResults<object>> DeleteFeedback(Feedback data, string user);
    }
}
