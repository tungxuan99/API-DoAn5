using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial class DiemBusiness : IDiemBusiness
    {
        private IDiemRepository _res;
        public DiemBusiness(IDiemRepository res)
        {
            _res = res;
        }
        public bool Create(DiemModel model)
        {
            return _res.Create(model);
        }
        public bool Update(DiemModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(int id)
        {
            return _res.Delete(id);
        }
        public DiemModel GetDatabyID(int id)
        {
            return _res.GetDatabyID(id);
        }
        public List<DiemModel> GetDataAll()
        {
            return _res.GetDataAll();
        }
        public List<DiemModel> Search(int pageIndex, int pageSize, out long total, string lop, string monhoc, string buoi, string ngay)
        {
            return _res.Search(pageIndex, pageSize, out total, lop, monhoc, buoi, ngay);
        }
    }

}
