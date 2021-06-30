using BLL.Interfaces;
using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial class HocSinhBusiness : IHocSinhBusiness
    {
        private IHocSinhRepository _res;
        public HocSinhBusiness(IHocSinhRepository res)
        {
            _res = res;
        }
        public bool Create(HocSinhModel model)
        {
            return _res.Create(model);
        }
        public bool Update(HocSinhModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(int id)
        {
            return _res.Delete(id);
        }
        public HocSinhModel GetDatabyID(int id)
        {
            return _res.GetDatabyID(id);
        }
        public List<HocSinhModel> GetDataAll()
        {
            return _res.GetDataAll();
        }

        public List<HocSinhModel> GetDataLop(string malop)
        {
            return _res.GetDataLop(malop);
        }
        public List<HocSinhModel> GetDataDiemHK(string Search)
        {
            return _res.GetDataDiemHK(Search);
        }
        public List<HocSinhModel> Search(int pageIndex, int pageSize, out long total, string hoten, string malophoc, string khoihoc)
        {
            return _res.Search(pageIndex, pageSize, out total, hoten, malophoc, khoihoc);
        }
    }
}
