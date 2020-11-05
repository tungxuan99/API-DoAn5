using DAL.Helper;
using DAL.Helper.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public partial class CTDiemDanhRepository : ICTDiemDanhRepository
    {
        private IDatabaseHelper _dbHelper;
        public CTDiemDanhRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public bool Create(CTDiemDanhModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "ct_diem_danh_create",
                "@MaDD", model.MaDD,
                "@MaHS", model.MaHS,
                "@TrangThai", model.TrangThai);
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

        public bool Delete(int id)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "ct_diem_danh_delete",
                "@id", id);
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
        public bool Update(CTDiemDanhModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "ct_diem_danh_update",
                "@ID", model.ID,
                "@MaDD", model.MaDD,
                "@MaHS", model.MaHS,
                "@TrangThai", model.TrangThai);
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
        public CTDiemDanhModel GetDatabyID(int id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "ctdiemdanh_get_by_id",
                     "@item_id", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<CTDiemDanhModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CTDiemDanhModel> GetDataAll()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "ctdiemdanh_all");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<CTDiemDanhModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CTDiemDanhModel> Search(int pageIndex, int pageSize, out long total, string lop, string namhoc, string kyhoc, string buoi)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "ct_diem_danh_search",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@lop", lop,
                    "@namhoc", namhoc,
                    "@kyhoc", kyhoc,
                    "@buoi", buoi);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<CTDiemDanhModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
