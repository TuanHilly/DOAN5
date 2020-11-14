using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
   public class LoaiSP
    {
        public string parent_maloai { get; set; }
        public string maloai { get; set; }
        public string tenloai { get; set; }
        public List<LoaiSP> children { get; set; }
        public string type { get; set; }
    }
}
