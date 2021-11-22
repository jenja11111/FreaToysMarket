﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreaToysMarket.Data.Models
{
    public class OrderDetail
    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        public int ItemID { get; set; }
        public uint Price { get; set; }
        public virtual Item Item { get; set; }
        public virtual Order Order { get; set; }
        
    }
}
