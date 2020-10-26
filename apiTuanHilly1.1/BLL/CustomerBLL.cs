using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class CustomerBLL : ICustomerBLL
    {
        private ICustomerDAL _res;
        public CustomerBLL(ICustomerDAL res)
        {
            _res = res;
        }
        public bool Create(CustomerModel model)
        {
            return _res.Create(model);
        }
    }

}
