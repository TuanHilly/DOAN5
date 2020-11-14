using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public partial interface ILoaiSPDAL
    {
        List<LoaiSP> GetData();
        LoaiSP GetDatabyID(string id);
        bool Create(LoaiSP model);
        bool Update(LoaiSP model);
        bool Delete(string id);
        List<LoaiSP> Search(int pageIndex, int pageSize, out long total, string tenloai);
    }
}
