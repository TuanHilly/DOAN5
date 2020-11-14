using System;
using System.Collections.Generic;
using System.Text;
using BLL.Interfaces;
using DAL.Interfaces;
using Model;

namespace BLL
{
    public class SanPhamBLL : ISanPhamBLL
    {
        private ISanPhamDAL _res;
        public SanPhamBLL(ISanPhamDAL LoaiSPRes)
        {
            _res = LoaiSPRes;
        }
        public bool Create(SanPham model)
        {
            return _res.Create(model);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public bool Update(SanPham model)
        {
            return _res.Update(model);
        }
        public List<SanPham> Search(int pageIndex, int pageSize, out long total, string tensp, decimal dongia)
        {
            return _res.Search(pageIndex, pageSize, out total, tensp, dongia);
        }
        public SanPham GetDatabyID(int id)
        {
            return _res.GetDatabyID(id);
        }
        public List<SanPham> GetDataAll(int page_index, int page_size, out long total)
        {
            return _res.GetDataAll(page_index, page_size, out total);
        }

        public List<SanPham> GetDataNew()
        {
            return _res.GetDataNew();
        }
        public List<SanPham> GetDataStatus()
        {
            return _res.GetDataStatus();
        }
        public List<SanPham> SearchCategory(int pageIndex, int pageSize, out long total, string maloai)
        {
            return _res.SearchCategory(pageIndex, pageSize, out total, maloai);
        }
        public List<SanPham> SearchBrand(int pageIndex, int pageSize, out long total, string mathuonghieu)
        {
            return _res.SearchBrand(pageIndex, pageSize, out total, mathuonghieu);
        }
    }

}