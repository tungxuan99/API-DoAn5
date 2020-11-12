using DAL.Helper;
using DAL.Helper.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public partial class HocSinhRepository : IHocSinhRepository
    {
        private IDatabaseHelper _dbHelper;
        public HocSinhRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public bool Create(HocSinhModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "hoc_sinh_create",
                "@MaHS", model.MaHS,
                "@MaLopHoc", model.MaLopHoc,
                "@TenHS", model.TenHS,
                "@GioiTinh", model.GioiTinh,
                "@NgaySinh", model.NgaySinh,
                "@NoiSinh", model.noisinh,
                "@DanToc", model.dantoc,
                "@HoTenCha", model.hotencha,
                "@HoTenMe", model.hotenme,
                "@password", model.passwordhs);
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
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "hoc_sinh_delete",
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
        public bool Update(HocSinhModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "hoc_sinh_update",
                "@MaHS", model.MaHS,
                "@MaLopHoc", model.MaLopHoc,
                "@TenHS", model.TenHS,
                "@GioiTinh", model.GioiTinh,
                "@NgaySinh", model.NgaySinh,
                "@NoiSinh", model.noisinh,
                "@DanToc", model.dantoc,
                "@HoTenCha", model.hotencha,
                "@HoTenMe", model.hotenme,
                "@password", model.passwordhs);
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
        public HocSinhModel GetDatabyID(int id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "hoc_sinh_get_by_id",
                     "@hs_id", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<HocSinhModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<HocSinhModel> GetDataAll()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "hoc_sinh_all");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<HocSinhModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<HocSinhModel> GetDataLop(string malop)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError,"hoc_sinh_by_lop", "@malop", malop);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<HocSinhModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<HocSinhModel> Search(int pageIndex, int pageSize, out long total, string hoten)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "hoc_sinh_search",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@hoten", hoten);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<HocSinhModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
