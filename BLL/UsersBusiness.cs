using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial class UsersBusiness : IUsersBusiness
    {
        private IUsersRepository _res;
        public UsersBusiness(IUsersRepository res)
        {
            _res = res;
        }
        public bool Create(UsersModel model)
        {
            return _res.Create(model);
        }
        public UsersModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public List<UsersModel> GetDataAll()
        {
            return _res.GetDataAll();
        }
    }

}
