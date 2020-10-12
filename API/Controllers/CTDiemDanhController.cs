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
    public class CTDiemDanhController : ControllerBase
    {
        private ICTDiemDanhBusiness _ctdiemdanhBusiness;
        public CTDiemDanhController(ICTDiemDanhBusiness ctdiemDanhBusiness)
        {
            _ctdiemdanhBusiness = ctdiemDanhBusiness;
        }

        [Route("create-ctdiem-danh")]
        [HttpPost]
        public CTDiemDanhModel CreateCTDiemDanh([FromBody] CTDiemDanhModel model)
        {

            return model;
        }
        [Route("get-by-id/{id}")]
        [HttpGet]
        public CTDiemDanhModel GetDatabyID(string id)
        {
            return _ctdiemdanhBusiness.GetDatabyID(id);
        }
        [Route("get-all")]
        [HttpGet]
        public IEnumerable<CTDiemDanhModel> GetDatabAll()
        {
            return _ctdiemdanhBusiness.GetDataAll();
        }
    }
}
