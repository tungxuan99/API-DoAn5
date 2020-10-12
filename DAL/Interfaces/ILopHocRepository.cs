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
    }
}
