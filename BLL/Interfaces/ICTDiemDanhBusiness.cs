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
    }
}

