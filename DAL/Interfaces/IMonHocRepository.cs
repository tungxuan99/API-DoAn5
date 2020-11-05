using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public partial interface IMonHocRepository
    {
        bool Create(MonHocModel model);
        bool Update(MonHocModel model);
        bool Delete(string id);
        MonHocModel GetDatabyID(string id);
        List<MonHocModel> GetDataAll();
        List<MonHocModel> Search(int pageIndex, int pageSize, out long total, string tenmon);
    }
}
