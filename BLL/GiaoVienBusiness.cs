using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial class GiaoVienBusiness : IGiaoVienBusiness
    {
        private IGiaoVienRepository _res;
        public GiaoVienBusiness(IGiaoVienRepository res)
        {
            _res = res;
        }
        public bool Create(GiaoVienModel model)
        {
            return _res.Create(model);
        }
        public GiaoVienModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public List<GiaoVienModel> GetDataAll()
        {
            return _res.GetDataAll();
        }
    }

}
