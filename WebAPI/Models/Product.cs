using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Product
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public int Total_Quality { get; set; }
        public string Image { get; set; }
        public string MoreImages { get; set; }
        public decimal Price { get; set; }
        public int PromotionPrice { get; set; }
        public string Detail { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public bool Status { get; set; }
    }
}
