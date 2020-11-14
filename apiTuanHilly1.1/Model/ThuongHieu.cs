using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
   public class ThuongHieu
    {
        public string mathuonghieu { get; set; }
        public string tenthuonghieu { get; set; }
        public string mota { get; set; }
        public List<ThuongHieu> children { get; set; }
        public string parent_mathuonghieu { get; set; }

        public string type { get; set; }

    }
}
