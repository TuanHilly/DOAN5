using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
   public partial interface ILoaiSPBLL
    {
        List<LoaiSP> GetData();
        LoaiSP GetDatabyID(string id);
        bool Create(LoaiSP model);
        bool Update(LoaiSP model);
        bool Delete(string id);
        List<LoaiSP> Search(int pageIndex, int pageSize, out long total, string tenloai);
    }
}
