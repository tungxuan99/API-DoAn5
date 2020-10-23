using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial interface IUsersBusiness
    {
        UsersModel Authenticate(string username, string password);
        bool Create(UsersModel model);
        bool Update(UsersModel model);
        bool Delete(int id);
        UsersModel GetDatabyID(int id);
        List<UsersModel> GetDataAll();
        List<UsersModel> Search(int pageIndex, int pageSize, out long total, string hoten, string taikhoan);
    }
}

