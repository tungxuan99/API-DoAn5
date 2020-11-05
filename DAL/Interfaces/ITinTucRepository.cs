using Model;
using System;
using System.Collections.Generic;
using System.Text;


namespace DAL
{
    public partial interface ITinTucRepository
    {
        bool Create(TinTucModel model);
        bool Update(TinTucModel model);
        bool Delete(int id);
        TinTucModel GetDatabyID(int id);
        List<TinTucModel> GetDataAll();
        List<TinTucModel> Search(int pageIndex, int pageSize, out long total, string tieude);
    }
}
