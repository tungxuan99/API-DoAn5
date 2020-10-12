using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial interface IGiaoVienBusiness
    {
        bool Create(GiaoVienModel model);
        GiaoVienModel GetDatabyID(string id);
        List<GiaoVienModel> GetDataAll();
    }
}

