using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public partial interface IHocSinhRepository
    {
        bool Create(HocSinhModel model);
        HocSinhModel GetDatabyID(string id);
        List<HocSinhModel> GetDataAll();
        List<HocSinhModel> Search(int pageIndex, int pageSize, out long total, string hoten);
    }
}
