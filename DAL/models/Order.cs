﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; } 

        public virtual Product Product { get; set; }

        Order() { }
    }

}