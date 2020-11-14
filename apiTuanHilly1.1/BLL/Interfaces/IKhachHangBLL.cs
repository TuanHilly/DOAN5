using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public partial interface IKhachHangBLL
    {
        bool CreateCustomer(KhachHang model);
        KhachHang GetDatabyID(string id);
        bool Update(KhachHang model);
        bool Delete(string id);
        List<KhachHang> Search(int pageIndex, int pageSize, out long total, string tenkh, string email);
    }
}

