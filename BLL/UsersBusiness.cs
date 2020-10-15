using DAL;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Model;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BLL
{
    public partial class UsersBusiness : IUsersBusiness
    {
        private IUsersRepository _res;
        private string Secret;
        public UsersBusiness(IUsersRepository res, IConfiguration configuration)
        {
            Secret = configuration["AppSettings:Secret"];
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
        public UsersModel Authenticate(string username, string password)
        {
            var user = _res.GetUser(username, password);
            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.username.ToString()),
                    new Claim(ClaimTypes.Role, user.level.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.token = tokenHandler.WriteToken(token);

            return user;

        }
        public List<UsersModel> Search(int pageIndex, int pageSize, out long total, string hoten, string taikhoan)
        {
            return _res.Search(pageIndex, pageSize, out total, hoten, taikhoan);
        }
    }

}
