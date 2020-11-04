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
        public HocSinhModel GetDatabyID(string id)
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
        public List<HocSinhModel> Search(int pageIndex, int pageSize, out long total, string hoten)
        {
            return _res.Search(pageIndex, pageSize, out total, hoten);
        }
    }
}
