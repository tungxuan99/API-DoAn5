using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public partial interface ILopHocRepository
    {
        bool Create(LopHocModel model);
        LopHocModel GetDatabyID(string id);
        List<LopHocModel> GetDataAll();

        List<LopHocModel> Search(int pageIndex, int pageSize, out long total, string tenlop);
    }
}
