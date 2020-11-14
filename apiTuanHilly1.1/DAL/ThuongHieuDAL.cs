using DAL.Helper;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class ThuongHieuDAL : IThuongHieuDAL
    {

        private IDatabaseHelper _dbHelper;
        public ThuongHieuDAL (IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public List<ThuongHieu> GetData()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_brand_get_data");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<ThuongHieu>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Create(ThuongHieu model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_brand_create",
                "@parent_mathuonghieu", model.parent_mathuonghieu,
                "@mathuonghieu", model.mathuonghieu,
                "@tenthuonghieu", model.tenthuonghieu,
                "@mota", model.mota);
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

        public bool Delete(string id)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_brand_delete",
                "@mathuonghieu", id);
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
        public bool Update(ThuongHieu model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_brand_update",

                "@mathuonghieu", model.mathuonghieu,
                "@tenthuonghieu", model.tenthuonghieu,
                "@mota", model.mota);
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
        public ThuongHieu GetDatabyID(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_brand_get_by_id",
                     "@mathuonghieu", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<ThuongHieu>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ThuongHieu> Search(int pageIndex, int pageSize, out long total, string tenthuonghieu)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_brand_search",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@tenthuonghieu", tenthuonghieu);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<ThuongHieu>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}