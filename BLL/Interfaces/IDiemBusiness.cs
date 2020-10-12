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
    }
}

