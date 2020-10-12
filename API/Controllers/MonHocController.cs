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
    public class MonHocController : ControllerBase
    {
        private IMonHocBusiness _monhocBusiness;
        public MonHocController(IMonHocBusiness monhocBusiness)
        {
            _monhocBusiness = monhocBusiness;
        }

        [Route("create-mon-hoc")]
        [HttpPost]
        public MonHocModel CreateCTDiemDanh([FromBody] MonHocModel model)
        {

            return model;
        }
        [Route("get-by-id/{id}")]
        [HttpGet]
        public MonHocModel GetDatabyID(string id)
        {
            return _monhocBusiness.GetDatabyID(id);
        }
        [Route("get-all")]
        [HttpGet]
        public IEnumerable<MonHocModel> GetDatabAll()
        {
            return _monhocBusiness.GetDataAll();
        }
    }
}
