using System;
using System.Collections.Generic;
using System.Text;
using BLL.Interfaces;
using DAL.Interfaces;
using Model;

namespace BLL
{
   public class KhachHangBLL:IKhachHangBLL
    {
        private IKhachHangDAL _res;
        public KhachHangBLL (IKhachHangDAL ikhachhang2)
        {
            _res = ikhachhang2;
        }
        public bool CreateCustomer(KhachHang model)
        {
            return _res.CreateCustomer(model);
        }

        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public KhachHang GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public bool Update(KhachHang model)
        {
            return _res.Update(model);
        }
        public List<KhachHang> Search(int pageIndex, int pageSize, out long total, string tenkh, string email)
        {
            return _res.Search(pageIndex, pageSize, out total, tenkh, email);
        }
    }

}
