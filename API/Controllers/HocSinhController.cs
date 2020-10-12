using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HocSinhController : ControllerBase
    {
        private IHocSinhBusiness _hocsinhBusiness;
        public HocSinhController(IHocSinhBusiness hoaDonBusiness)
        {
            _hocsinhBusiness = hoaDonBusiness;
        }

        [Route("create-hoc-sinh")]
        [HttpPost]
        public HocSinhModel CreateHocSinh([FromBody] HocSinhModel model)
        {

            return model;
        }
        [Route("get-by-id/{id}")]
        [HttpGet]
        public HocSinhModel GetDatabyID(string id)
        {
            return _hocsinhBusiness.GetDatabyID(id);
        }
        [Route("get-all")]
        [HttpGet]
        public IEnumerable<HocSinhModel> GetDatabAll()
        {
            return _hocsinhBusiness.GetDataAll();
        }
    }
}
