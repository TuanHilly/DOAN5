using System;
using System.Collections.Generic;

namespace Model
{
    public class BillModel
    {
        public int ID { get; set; }
        public string Payment { get; set; }
        public string Total { get; set; }
        public string Note { get; set; }
        public string DateOrder { get; set; }
        public int ID_product { get; set; }
        public string Price { get; set; }
        public int Quantity { get; set; }

    }
}
