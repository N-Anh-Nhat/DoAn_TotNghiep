﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class News
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Detai_Name { get; set; }
        public string Content_news { get; set; }
        public string Image { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public bool Status { get; set; }
        public int ID_Catelogy { get; set; }
    }
}
