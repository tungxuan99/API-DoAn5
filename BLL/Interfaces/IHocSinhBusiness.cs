using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public partial interface IHocSinhBusiness
    {
        bool Create(HocSinhModel model);
        HocSinhModel GetDatabyID(string id);
        List<HocSinhModel> GetDataAll();
    }
}
