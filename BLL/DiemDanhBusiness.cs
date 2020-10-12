using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial class DiemDanhBusiness : IDiemDanhBusiness
    {
        private IDiemDanhRepository _res;
        public DiemDanhBusiness(IDiemDanhRepository res)
        {
            _res = res;
        }
        public bool Create(DiemDanhModel model)
        {
            return _res.Create(model);
        }
        public DiemDanhModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public List<DiemDanhModel> GetDataAll()
        {
            return _res.GetDataAll();
        }
    }

}
