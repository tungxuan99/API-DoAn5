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
            return true;
        }
        public HocSinhModel GetDatabyID(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "hoc_sinh_get_by_id",
                     "@item_id", id);
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
    }
}
