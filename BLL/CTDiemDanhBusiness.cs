using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial class CTDiemDanhBusiness : ICTDiemDanhBusiness
    {
        private ICTDiemDanhRepository _res;
        public CTDiemDanhBusiness(ICTDiemDanhRepository res)
        {
            _res = res;
        }
        public bool Create(CTDiemDanhModel model)
        {
            return _res.Create(model);
        }
        public CTDiemDanhModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public List<CTDiemDanhModel> GetDataAll()
        {
            return _res.GetDataAll();
        }
        public List<CTDiemDanhModel> Search(int pageIndex, int pageSize, out long total, string lop, string namhoc, string kyhoc, string buoi)
        {
            return _res.Search(pageIndex, pageSize, out total, lop, namhoc, kyhoc, buoi);
        }
    }

}
