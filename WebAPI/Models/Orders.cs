using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Orders
    {
        public int ID { get; set; }
        public string Name_order { get; set; }
        public string Type_ship { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Note { get; set; }
        public string Phone { get; set; }
        public decimal ToTal_Money { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public bool Status { get; set; }
        public int ID_User { get; set; }
        public int ID_TrangThaiDonHang { get; set; }
    }
}
