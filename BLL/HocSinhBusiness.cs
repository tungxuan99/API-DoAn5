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
    }
}
