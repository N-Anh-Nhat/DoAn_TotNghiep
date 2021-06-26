using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Order_Detail
    {
        public int ID { get; set; }
        public int Quality { get; set; }
        public decimal Total_monney { get; set; }
        public int PromotionPrice { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public bool Status { get; set; }
    }
}
