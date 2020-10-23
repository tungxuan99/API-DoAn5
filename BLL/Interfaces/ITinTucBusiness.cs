using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial interface ITinTucBusiness
    {
        bool Create(TinTucModel model);
        TinTucModel GetDatabyID(string id);
        List<TinTucModel> GetDataAll();
        List<TinTucModel> Search(int pageIndex, int pageSize, out long total, string tieude);
    }
}
