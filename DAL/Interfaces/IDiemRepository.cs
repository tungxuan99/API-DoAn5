using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public partial interface IDiemRepository
    {
        bool Create(DiemModel model);
        DiemModel GetDatabyID(string id);
        List<DiemModel> GetDataAll();
    }
}
