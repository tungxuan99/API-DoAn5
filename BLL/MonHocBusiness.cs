using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial class MonHocBusiness : IMonHocBusiness
    {
        private IMonHocRepository _res;
        public MonHocBusiness(IMonHocRepository res)
        {
            _res = res;
        }
        public bool Create(MonHocModel model)
        {
            return _res.Create(model);
        }
        public bool Update(MonHocModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public MonHocModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public List<MonHocModel> GetDataAll()
        {
            return _res.GetDataAll();
        }
        public List<MonHocModel> Search(int pageIndex, int pageSize, out long total, string tenmon)
        {
            return _res.Search(pageIndex, pageSize, out total, tenmon);
        }
    }

}
