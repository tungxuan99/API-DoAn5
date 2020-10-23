using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial interface IMonHocBusiness
    {
        bool Create(MonHocModel model);
        MonHocModel GetDatabyID(string id);
        List<MonHocModel> GetDataAll();
        List<MonHocModel> Search(int pageIndex, int pageSize, out long total, string tenmon);
    }
}

