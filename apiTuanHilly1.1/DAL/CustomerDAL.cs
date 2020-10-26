using DAL.Helper;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public partial class CustomerDAL : ICustomerDAL
    {
        private IDatabaseHelper _dbHelper;
        public CustomerDAL(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public bool Create(CustomerModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_customer_create",
                "@ID", model.ID,
                "@Name", model.Name,
                "@Email", model.Email);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
