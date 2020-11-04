using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial class LopHocBusiness : ILopHocBusiness
    {
        private ILopHocRepository _res;
        public LopHocBusiness(ILopHocRepository res)
        {
            _res = res;
        }
        public bool Create(LopHocModel model)
        {
            return _res.Create(model);
        }
        public bool Update(LopHocModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public LopHocModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public List<LopHocModel> GetDataAll()
        {
            return _res.GetDataAll();
        }
        public List<LopHocModel> Search(int pageIndex, int pageSize, out long total, string tenlop)
        {
            return _res.Search(pageIndex, pageSize, out total, tenlop);
        }
    }

}
