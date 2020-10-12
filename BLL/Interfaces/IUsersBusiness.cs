using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial interface IUsersBusiness
    {
        bool Create(UsersModel model);
        UsersModel GetDatabyID(string id);
        List<UsersModel> GetDataAll();
    }
}

