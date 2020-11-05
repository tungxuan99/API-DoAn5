using DAL.Helper;
using DAL.Helper.Interfaces;
using DAL;
using System;
using Model;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DAL
{
    public partial class TinTucRepository : ITinTucRepository
    {
        private IDatabaseHelper _dbHelper;
        public TinTucRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public bool Create(TinTucModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "tin_tuc_create",
                "@MaTinTuc", model.MaTinTuc,
                "@TieuDe", model.TieuDe,
                "@NoiDung", model.NoiDung,
                "@HinhAnh", model.Anh,
                "@TrangThai", model.TrangThai,
                "@IDTaiKhoan", model.IDTaiKhoan);
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
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "tin_tuc_delete",
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
        public bool Update(TinTucModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "tin_tuc_update",
                "@MaTinTuc", model.MaTinTuc,
                "@TieuDe", model.TieuDe,
                "@NoiDung", model.NoiDung,
                "@HinhAnh", model.Anh,
                "@TrangThai", model.TrangThai,
                "@IDTaiKhoan", model.IDTaiKhoan);
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
        public TinTucModel GetDatabyID(int id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "tin_tuc_get_by_id",
                     "@item_id", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<TinTucModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<TinTucModel> GetDataAll()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "tin_tuc_all");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<TinTucModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<TinTucModel> Search(int pageIndex, int pageSize, out long total, string tieude)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "tin_tuc_search",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@tieude", tieude);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<TinTucModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
