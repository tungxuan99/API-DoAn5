﻿using DAL.Helper;
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
                "@diem_id", model.id,
                "@diem_MaHocKy ", model.MaHocKy,
                "@diem_MaMonHoc  ", model.MaMonHoc,
                "@diem_MaHS ", model.MaHS,
                "@diem_MaLop ", model.MaLopHoc,
                "@diem_DiemMieng", model.DiemMieng,
                "@diem_Diem15Phut", model.Diem15Phut,
                "@diem_Diem1Tiet", model.Diem1Tiet,
                "@diem_DiemHK", model.DiemHK,
                "@diem_DiemTB", Math.Round(model.DiemTB,2));
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
                "@diem_id", model.id,
                "@diem_MaHocKy", model.MaHocKy,
                "@diem_MaMonHoc", model.MaMonHoc,
                "@diem_MaHS", model.MaHS,
                "@diem_MaLop", model.MaLopHoc,
                "@diem_DiemMieng", model.DiemMieng,
                "@diem_Diem15Phut", model.Diem15Phut,
                "@diem_Diem1Tiet", model.Diem1Tiet,
                "@diem_DiemHK", model.DiemHK,
                "@diem_DiemTB", model.DiemTB);
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
        public List<DiemTBMon> GetDiemTBMonbyHK(string MaHocKy)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "DiemTBMon_by_HK",
                     "@MaHK", MaHocKy);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<DiemTBMon>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<DiemTBHK> GetDiemTBbyHK(string MaHocKy)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "DiemTBKyHoc",
                     "@KyHoc", MaHocKy);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<DiemTBHK>().ToList();
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

        public List<XemDiemMon> GetDiemByLopMaHKMon(string MaLop, string MaHocKy, string MaMon)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "xem_diem_get_by_malop_hk_mon",
                     "@MaLop", MaLop, "@MaHocKy", MaHocKy, "@MaMon", MaMon);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<XemDiemMon>().ToList();
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

        public DiemModel GetEndDiem()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "enddiem");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<DiemModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<XemDiemLop> GetDiemByLopMaHK(string MaLop, string MaHocKy)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "xem_diem_get_by_malop_mahk",
                     "@MaLop", MaLop, "@MaHK", MaHocKy);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<XemDiemLop>().ToList();
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
