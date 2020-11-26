using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public partial interface IHocSinhRepository
    {
        bool Create(HocSinhModel model);
        bool Update(HocSinhModel model);
        bool Delete(int id);
        HocSinhModel GetDatabyID(int id);
        List<HocSinhModel> GetDataDiemHK(string Search);
        List<HocSinhModel> GetDataAll();
        List<HocSinhModel> GetDataLop(string malop);
        List<HocSinhModel> Search(int pageIndex, int pageSize, out long total, string hoten);
    }
}
