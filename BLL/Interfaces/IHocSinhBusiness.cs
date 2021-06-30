using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public partial interface IHocSinhBusiness
    {
        bool Create(HocSinhModel model);
        bool Update(HocSinhModel model);
        bool Delete(int id);
        List<HocSinhModel> GetDataDiemHK(string Search);
        HocSinhModel GetDatabyID(int id);
        List<HocSinhModel> GetDataAll();
        List<HocSinhModel> GetDataLop(string malop);
        List<HocSinhModel> Search(int pageIndex, int pageSize, out long total, string hoten, string malophoc, string khoihoc);
    }
}
