using DAL.Helper;
using DAL.Helper.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public partial class DiemDanhRepository : IDiemDanhRepository
    {
        private IDatabaseHelper _dbHelper;
        public DiemDanhRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public bool Create(DiemDanhModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "diem_danh_create",

                "@MaLopHoc", model.MaLopHoc,
                "@MaGV", model.Magv,
                "@Buoi", model.Buoi,
                "@NgayDD", model.NgayDD);
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
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "diem_danh_delete",
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
        public bool Update(DiemDanhModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "diem_danh_update",
                "@MaDD", model.MaDD,
                "@MaLopHoc", model.MaLopHoc,
                "@MaGV", model.Magv,
                "@Buoi", model.Buoi,
                "@NgayDD", model.NgayDD);
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
        public DiemDanhModel GetDatabyID(int id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "diem_danh_get_by_id",
                     "@item_id", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<DiemDanhModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<DiemDanhModel> GetDataAll()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "diem_danh_all");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<DiemDanhModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<DiemDanhModel> Search(int pageIndex, int pageSize, out long total, string monhoc, string buoi, string ngay)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "diem_danh_search",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@monhoc", monhoc,
                    "@buoi", buoi,
                    "@ngay", ngay);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<DiemDanhModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
