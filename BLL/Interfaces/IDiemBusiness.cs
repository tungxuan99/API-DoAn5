using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial interface IDiemBusiness
    {
        bool Create(DiemModel model);
        DiemModel GetDatabyID(string id);
        List<DiemModel> GetDataAll();
        List<DiemModel> Search(int pageIndex, int pageSize, out long total, string lop, string monhoc, string buoi, string ngay);
    }
}

