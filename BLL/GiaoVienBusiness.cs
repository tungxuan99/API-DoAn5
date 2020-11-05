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
        public bool Update(GiaoVienModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public GiaoVienModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public List<GiaoVienModel> GetDataAll()
        {
            return _res.GetDataAll();
        }
        public List<GiaoVienModel> Search(int pageIndex, int pageSize, out long total, string hoten)
        {
            return _res.Search(pageIndex, pageSize, out total, hoten);
        }
    }

}
