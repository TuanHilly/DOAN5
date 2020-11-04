using System;
using System.Collections.Generic;
using System.Text;


namespace Model
{
    public class ProductModel
    {
        public int product_id { get; set; }
        public int category_id { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public int Quantity { get; set; }
        public string Unit_price { get; set; }
        public string Promotion_price { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Status { get; set; }

    }
}
