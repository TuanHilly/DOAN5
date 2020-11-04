using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial class BillBLL : IBillBLL
    {
        private IBillDAL _res;
        public BillBLL(IBillDAL res)
        {
            _res = res;
        }
        public bool Create(BillModel model)
        {
            return _res.Create(model);
        }
    }
}
