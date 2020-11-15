using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial interface IGiaoVienBusiness
    {
        bool Create(GiaoVienModel model);
        bool Update(GiaoVienModel model);
        bool Delete(int id);
        GiaoVienModel GetDatabyID(int id);
        List<GiaoVienModel> GetDataAll();
        List<GiaoVienModel> Search(int pageIndex, int pageSize, out long total, string hoten);
    }
}

