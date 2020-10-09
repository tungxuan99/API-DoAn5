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
        public TinTucModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public List<TinTucModel> GetDataAll()
        {
            return _res.GetDataAll();
        }
    }
}
