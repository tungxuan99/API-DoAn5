using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUsersBusiness _usersBusiness;
        public UsersController(IUsersBusiness usersBusiness)
        {
            _usersBusiness = usersBusiness;
        }

        [Route("create-users")]
        [HttpPost]
        public UsersModel CreateCTDiemDanh([FromBody] UsersModel model)
        {

            return model;
        }
        [Route("get-by-id/{id}")]
        [HttpGet]
        public UsersModel GetDatabyID(string id)
        {
            return _usersBusiness.GetDatabyID(id);
        }
        [Route("get-all")]
        [HttpGet]
        public IEnumerable<UsersModel> GetDatabAll()
        {
            return _usersBusiness.GetDataAll();
        }
    }
}
