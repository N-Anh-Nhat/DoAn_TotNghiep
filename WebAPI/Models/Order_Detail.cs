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
        public string Note { get; set; }
        public int PromotionPrice { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public bool Status { get; set; }
        public int ID_Order { get; set; }
        public int ID_Product { get; set; }
        public int ID_Size { get; set; }
    }
}
