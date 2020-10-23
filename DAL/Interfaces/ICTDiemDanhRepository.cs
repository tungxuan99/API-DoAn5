﻿using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public partial interface ICTDiemDanhRepository
    {
        bool Create(CTDiemDanhModel model);
        CTDiemDanhModel GetDatabyID(string id);
        List<CTDiemDanhModel> GetDataAll();
        List<CTDiemDanhModel> Search(int pageIndex, int pageSize, out long total, string lop, string namhoc, string kyhoc, string buoi);
    }
}
