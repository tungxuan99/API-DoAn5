using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial interface IDiemDanhBusiness
    {
        bool Create(DiemDanhModel model);
        DiemDanhModel GetDatabyID(string id);
        List<DiemDanhModel> GetDataAll();
    }
}

