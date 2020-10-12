using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial class DiemBusiness : IDiemBusiness
    {
        private IDiemRepository _res;
        public DiemBusiness(IDiemRepository res)
        {
            _res = res;
        }
        public bool Create(DiemModel model)
        {
            return _res.Create(model);
        }
        public DiemModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public List<DiemModel> GetDataAll()
        {
            return _res.GetDataAll();
        }
    }

}
