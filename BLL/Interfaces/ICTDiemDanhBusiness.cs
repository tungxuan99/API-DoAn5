using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial interface ICTDiemDanhBusiness
    {
        bool Create(CTDiemDanhModel model);
        CTDiemDanhModel GetDatabyID(string id);
        List<CTDiemDanhModel> GetDataAll();
        List<CTDiemDanhModel> Search(int pageIndex, int pageSize, out long total, string lop, string namhoc, string kyhoc, string buoi);
    }
}

