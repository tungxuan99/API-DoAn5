﻿using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial interface ILopHocBusiness
    {
        bool Create(LopHocModel model);
        bool Update(LopHocModel model);
        bool Delete(string id);
        LopHocModel GetDatabyID(string id);
        List<LopHocModel> GetDataAll();
        List<LopHocModel> Search(int pageIndex, int pageSize, out long total, string tenlop);
    }
}

