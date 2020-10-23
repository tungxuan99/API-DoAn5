using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public partial interface IDiemDanhRepository
    {
        bool Create(DiemDanhModel model);
        DiemDanhModel GetDatabyID(string id);
        List<DiemDanhModel> GetDataAll();
        List<DiemDanhModel> Search(int pageIndex, int pageSize, out long total, string monhoc, string buoi, string ngay);
    }
}
