using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public partial interface ISanPhamDAL
    {
        bool Create(SanPham model);
        bool Update(SanPham model);
        bool Delete(string id);
        List<SanPham> Search(int pageIndex, int pageSize, out long total, string tensp, decimal dongia);
        SanPham GetDatabyID(int id);
        List<SanPham> GetDataAll(int page_index, int page_size, out long total);
        List<SanPham> GetDataNew();
        List<SanPham> GetDataStatus();
        List<SanPham> SearchCategory(int pageIndex, int pageSize, out long total, string maloai);
        List<SanPham> SearchBrand(int pageIndex, int pageSize, out long total, string mathuonghieu);
    }
}
