using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
   public class SanPham
    {
        public int masp { get; set; }
        public string tensp { get; set; }
        public string xuatxu { get; set; }
        public string mota { get; set; }
        public decimal? dongia { get; set; }
        public int soluong { get; set; }
        public string anh { get; set; }
        public string maloai { get; set; }
        public string mathuonghieu { get; set; }
        public long? total { get; set; }
        public string status { get; set; }
    }
}
