using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial class DiemDanhBusiness : IDiemDanhBusiness
    {
        private IDiemDanhRepository _res;
        public DiemDanhBusiness(IDiemDanhRepository res)
        {
            _res = res;
        }
        public bool Create(DiemDanhModel model)
        {
            return _res.Create(model);
        }
        public bool Update(DiemDanhModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(int id)
        {
            return _res.Delete(id);
        }
        public DiemDanhModel GetDatabyID(int id)
        {
            return _res.GetDatabyID(id);
        }
        public List<DiemDanhModel> GetDataAll()
        {
            return _res.GetDataAll();
        }
        public List<DiemDanhModel> Search(int pageIndex, int pageSize, out long total, string monhoc, string buoi, string ngay)
        {
            return _res.Search(pageIndex, pageSize, out total, monhoc, buoi, ngay);
        }
    }

}
