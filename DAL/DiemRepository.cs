using DAL.Helper;
using DAL.Helper.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public partial class DiemRepository : IDiemRepository
    {
        private IDatabaseHelper _dbHelper;
        public DiemRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public bool Create(DiemModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "diem_create",
                "@MaHocKy", model.MaHocKy,
                "@MaMonHoc", model.MaMonHoc,
                "@MaHS", model.MaHS,
                "@MaLopHoc", model.MaLopHoc,
                "@DiemMieng", model.DiemMieng,
                "@Diem15Phut", model.Diem15Phut,
                "@Diem1Tiet", model.Diem1Tiet,
                "@DiemHK", model.DiemHK,
                "@DiemTB", model.DiemTB);
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
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "diem_delete",
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
        public bool Update(DiemModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "diem_update",
                "@id", model.id,
                "@MaHocKy", model.MaHocKy,
                "@MaMonHoc", model.MaMonHoc,
                "@MaHS", model.MaHS,
                "@MaLopHoc", model.MaLopHoc,
                "@DiemMieng", model.DiemMieng,
                "@Diem15Phut", model.Diem15Phut,
                "@Diem1Tiet", model.Diem1Tiet,
                "@DiemHK", model.DiemHK,
                "@DiemTB", model.DiemTB);
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
        public DiemModel GetDatabyID(int id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "diem_get_by_id",
                     "@item_id", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<DiemModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<DiemHS> GetDatabyHSHK(int MaHS, string MaHK)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "diem_get_by_mahs_hk",
                     "@MaHS", MaHS, "@MaHocKy", MaHK);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<DiemHS>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<TopDiem> GetDataTop10Diem(string MaHK)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "Top10_diemTB_by_hk",
                     "@MaHK", MaHK);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<TopDiem>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<XemDiemHK> GetDataDiemHK(string Search, string MaHK)
        {
            string msgError = "";
            int MaHS = 0;
            string TenHS="";
            bool kt= int.TryParse(Search, out MaHS);
            if (kt == false)
            {
                TenHS = Search;
                try
                {
                    var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "xem_diem_get_by_tenhs_hk",
                         "@TenHS", TenHS, "@MaHocKy", MaHK);
                    if (!string.IsNullOrEmpty(msgError))
                        throw new Exception(msgError);
                    return dt.ConvertTo<XemDiemHK>().ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                try
                {
                    var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "xem_diem_get_by_mahs_hk",
                          "@MaHS", MaHS, "@MaHocKy", MaHK);
                    if (!string.IsNullOrEmpty(msgError))
                        throw new Exception(msgError);
                    return dt.ConvertTo<XemDiemHK>().ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public List<DiemModel> GetDataAll()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "diem_all");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<DiemModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<DiemModel> Search(int pageIndex, int pageSize, out long total, string lop, string namhoc, string kyhoc, string monhoc)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "diem_search",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@lop", lop,
                    "@namhoc", namhoc,
                    "@kyhoc", kyhoc,
                    "@monhoc", monhoc);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<DiemModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
