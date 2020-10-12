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
    public class GiaoVienController : ControllerBase
    {
        private IGiaoVienBusiness _giaovienBusiness;
        public GiaoVienController(IGiaoVienBusiness giaovienBusiness)
        {
            _giaovienBusiness = giaovienBusiness;
        }

        [Route("create-giao-vien")]
        [HttpPost]
        public GiaoVienModel CreateCTDiemDanh([FromBody] GiaoVienModel model)
        {

            return model;
        }
        [Route("get-by-id/{id}")]
        [HttpGet]
        public GiaoVienModel GetDatabyID(string id)
        {
            return _giaovienBusiness.GetDatabyID(id);
        }
        [Route("get-all")]
        [HttpGet]
        public IEnumerable<GiaoVienModel> GetDatabAll()
        {
            return _giaovienBusiness.GetDataAll();
        }
    }
}
