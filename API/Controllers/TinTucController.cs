using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Model;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TinTucController : ControllerBase
    {
        private ITinTucBusiness _tintucBusiness;
        public TinTucController(ITinTucBusiness hoaDonBusiness)
        {
            _tintucBusiness = hoaDonBusiness;
        }

        [Route("create-hoa-don")]
        [HttpPost]
        public TinTucModel CreateTinTuc([FromBody] TinTucModel model)
        {
            
            return model;
        }
        [Route("get-by-id/{id}")]
        [HttpGet]
        public TinTucModel GetDatabyID(string id)
        {
            return _tintucBusiness.GetDatabyID(id);
        }
        [Route("get-all")]
        [HttpGet]
        public IEnumerable<TinTucModel> GetDatabAll()
        {
            return _tintucBusiness.GetDataAll();
        }
    }
}
