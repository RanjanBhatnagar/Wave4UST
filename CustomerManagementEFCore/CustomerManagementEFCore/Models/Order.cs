﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementEFCore.Models
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public int OrderQty { get; set; }
        public int QtyDisp { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

    }
}
