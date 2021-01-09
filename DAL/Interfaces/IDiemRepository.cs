using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public partial interface IDiemRepository
    {
        bool Create(DiemModel model);
        bool Update(DiemModel model);
        bool Delete(int id);
        DiemModel GetDatabyID(int id);
        List<DiemHS> GetDatabyHSHK(int MaHS, string MaHK);
        List<TopDiem> GetDataTop10Diem(string MaHK);
        List<DiemTBMon> GetDiemTBMonbyHK(string MaHocKy);
        List<XemDiemHK> GetDataDiemHK(string Search, string MaHK);
        List<DiemModel> GetDataAll();
        List<DiemTBHK> GetDiemTBbyHK(string MaHocKy);
        List<DiemModel> Search(int pageIndex, int pageSize, out long total, string lop, string namhoc, string kyhoc, string monhoc);
    }
}
