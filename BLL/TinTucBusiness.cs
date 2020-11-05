using BLL;
using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial class TinTucBusiness : ITinTucBusiness
    {
        private ITinTucRepository _res;
        public TinTucBusiness(ITinTucRepository res)
        {
            _res = res;
        }
        public bool Create(TinTucModel model)
        {
            return _res.Create(model);
        }
        public bool Update(TinTucModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(int id)
        {
            return _res.Delete(id);
        }
        public TinTucModel GetDatabyID(int id)
        {
            return _res.GetDatabyID(id);
        }
        public List<TinTucModel> GetDataAll()
        {
            return _res.GetDataAll();
        }
        public List<TinTucModel> Search(int pageIndex, int pageSize, out long total, string tieude)
        {
            return _res.Search(pageIndex, pageSize, out total, tieude);
        }
    }
}
