using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class ADS
    {
        public int ID { get; set; }
        public string Name_ADS { get; set;}
        public string Content_ADS { get; set; }
        public DateTime Thoi_Han { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public bool Status { get; set; }
    }
}
