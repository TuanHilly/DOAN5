using DAL.Helper;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public partial class HDBDAL : IHDBDAL
    {
        private IDatabaseHelper _dbHelper;
        public HDBDAL(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public bool Create(HDB model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_hoa_don_create",
                "@ma_hoa_don", model.ma_hoa_don,
                "@ho_ten", model.ho_ten,
                "@dia_chi", model.dia_chi,
                "@sdt", model.sdt,
                "@order_total", model.order_total,
                "@listjson_chitiet", model.listjson_chitiet != null ? MessageConvert.SerializeObject(model.listjson_chitiet) : null);
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
        public List<HDB> GetDataAll()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_hoa_don_all");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<HDB>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HDB> Search(int pageIndex, int pageSize, out long total, string ho_ten)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_hoa_don_search",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@ho_ten", ho_ten);

                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<HDB>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public HDB GetDatabyID(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_hoadon_get_by_id",
                     "@ma_hoa_don", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<HDB>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CTHDB> GetChitietbyhoadon(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_chitiet_by_hoadon",
                     "@ma_hoa_don", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<CTHDB>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
    