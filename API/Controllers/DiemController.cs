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
    public class DiemController : ControllerBase
    {
        private IDiemBusiness _diemBusiness;
        public DiemController(IDiemBusiness diemBusiness)
        {
            _diemBusiness = diemBusiness;
        }

        [Route("create-diem")]
        [HttpPost]
        public DiemModel CreateCTDiemDanh([FromBody] DiemModel model)
        {

            return model;
        }
        [Route("get-by-id/{id}")]
        [HttpGet]
        public DiemModel GetDatabyID(string id)
        {
            return _diemBusiness.GetDatabyID(id);
        }
        [Route("get-all")]
        [HttpGet]
        public IEnumerable<DiemModel> GetDatabAll()
        {
            return _diemBusiness.GetDataAll();
        }
    }
}
