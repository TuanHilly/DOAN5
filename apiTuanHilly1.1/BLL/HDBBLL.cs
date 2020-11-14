using BLL.Interfaces;
using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class HDBBLL : IHDBBLL
    {
        private IHDBDAL _res;
        private ISanPhamBLL _rsp;
        public HDBBLL(IHDBDAL res, ISanPhamBLL rsp)
        {
            _res = res;
            _rsp = rsp;
        }
        public bool Create(HDB model)
        {
            return _res.Create(model);
        }
        public HDB GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }

        public HDB GetChiTietByHoaDon(string id)
        {
            var kq = _res.GetDatabyID(id);

            kq.listjson_chitiet = _res.GetChitietbyhoadon(id);
            foreach (var item in kq.listjson_chitiet)
            {
                item.tensp = _rsp.GetDatabyID(item.masp).tensp;
                item.dongia = _rsp.GetDatabyID(item.masp).dongia.Value;
            }

            return kq;
        }



        public List<HDB> GetDataAll()
        {
            return _res.GetDataAll();
        }

        public List<HDB> Search(int pageIndex, int pageSize, out long total, string ho_ten)
        {
            return _res.Search(pageIndex, pageSize, out total, ho_ten);

        }
    }

}
   