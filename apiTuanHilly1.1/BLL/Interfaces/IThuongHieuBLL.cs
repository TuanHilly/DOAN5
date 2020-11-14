using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public partial interface IThuongHieuBLL
    {
        List<ThuongHieu> GetData();
        ThuongHieu GetDatabyID(string id);
        bool Create(ThuongHieu model);
        bool Update(ThuongHieu model);
        bool Delete(string id);
        List<ThuongHieu> Search(int pageIndex, int pageSize, out long total, string tenthuonghieu);
    }
}
