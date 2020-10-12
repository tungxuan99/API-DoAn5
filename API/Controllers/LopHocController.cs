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
    public class LopHocController : ControllerBase
    {
        private ILopHocBusiness _lophocBusiness;
        public LopHocController(ILopHocBusiness lophocBusiness)
        {
            _lophocBusiness = lophocBusiness;
        }

        [Route("create-lop-hoc")]
        [HttpPost]
        public LopHocModel CreateCTDiemDanh([FromBody] LopHocModel model)
        {

            return model;
        }
        [Route("get-by-id/{id}")]
        [HttpGet]
        public LopHocModel GetDatabyID(string id)
        {
            return _lophocBusiness.GetDatabyID(id);
        }
        [Route("get-all")]
        [HttpGet]
        public IEnumerable<LopHocModel> GetDatabAll()
        {
            return _lophocBusiness.GetDataAll();
        }
    }
}
