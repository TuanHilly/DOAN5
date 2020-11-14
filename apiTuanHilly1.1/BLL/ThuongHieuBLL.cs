using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.Interfaces;
using DAL.Interfaces;
using Model;

namespace BLL
{
    public partial class ThuongHieuBLL : IThuongHieuBLL
    {
        private IThuongHieuDAL _res;
        public ThuongHieuBLL(IThuongHieuDAL ithuonghieu2)
        {
            _res = ithuonghieu2;
        }
        public List<ThuongHieu> GetData()
        {
            var allBrand = _res.GetData();
            var lstParent = allBrand.Where(ds => ds.parent_mathuonghieu == null).OrderBy(s => s.mathuonghieu).ToList();
            foreach (var item in lstParent)
            {
                item.children = GetHiearchyList(allBrand, item);
            }
            return lstParent;
        }
        public List<ThuongHieu> GetHiearchyList(List<ThuongHieu> lstAll, ThuongHieu node)
        {
            var lstChilds = lstAll.Where(ds => ds.parent_mathuonghieu == node.mathuonghieu).ToList();
            if (lstChilds.Count == 0)
                return null;
            for (int i = 0; i < lstChilds.Count; i++)
            {
                var childs = GetHiearchyList(lstAll, lstChilds[i]);
                lstChilds[i].type = (childs == null || childs.Count == 0) ? "leaf" : "";
                lstChilds[i].children = childs;
            }
            return lstChilds.OrderBy(s => s.mathuonghieu).ToList();
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public ThuongHieu GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public bool Create(ThuongHieu model)
        {
            return _res.Create(model);
        }
        public bool Update(ThuongHieu model)
        {
            return _res.Update(model);
        }
        public List<ThuongHieu> Search(int pageIndex, int pageSize, out long total, string tenthuonghieu)
        {
            return _res.Search(pageIndex, pageSize, out total, tenthuonghieu);
        }


    }
}