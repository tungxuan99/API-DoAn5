using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public partial interface IUsersRepository
    {
        UsersModel GetUser(string username, string password);
        bool Create(UsersModel model);
        UsersModel GetDatabyID(string id);
        List<UsersModel> GetDataAll();
        List<UsersModel> Search(int pageIndex, int pageSize, out long total, string hoten, string taikhoan);
    }
}
