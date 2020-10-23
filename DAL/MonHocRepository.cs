﻿using DAL.Helper;
using DAL.Helper.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public partial class MonHocRepository : IMonHocRepository
    {
        private IDatabaseHelper _dbHelper;
        public MonHocRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public bool Create(MonHocModel model)
        {
            string msgError = "";
            return true;
        }
        public MonHocModel GetDatabyID(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "mon_get_by_id",
                     "@item_id", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<MonHocModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<MonHocModel> GetDataAll()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "mon_hoc_all");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<MonHocModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<MonHocModel> Search(int pageIndex, int pageSize, out long total, string tenmon)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "mon_hoc_search",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@tenmon", tenmon);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<MonHocModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
