using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial interface IDiemBusiness
    {
        bool Create(DiemModel model);
        bool Update(DiemModel model);
        bool Delete(int id);
        DiemModel GetDatabyID(int id);
        List<DiemModel> GetDataAll();
        List<DiemModel> Search(int pageIndex, int pageSize, out long total, string lop, string monhoc, string buoi, string ngay);
    }
}

