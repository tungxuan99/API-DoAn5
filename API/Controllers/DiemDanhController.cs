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
    public class DiemDanhController : ControllerBase
    {
        private IDiemDanhBusiness _diemdanhBusiness;
        public DiemDanhController(IDiemDanhBusiness diemDanhBusiness)
        {
            _diemdanhBusiness = diemDanhBusiness;
        }

        [Route("create-diem-danh")]
        [HttpPost]
        public DiemDanhModel CreateDiemDanh([FromBody] DiemDanhModel model)
        {

            return model;
        }
        [Route("get-by-id/{id}")]
        [HttpGet]
        public DiemDanhModel GetDatabyID(string id)
        {
            return _diemdanhBusiness.GetDatabyID(id);
        }
        [Route("get-all")]
        [HttpGet]
        public IEnumerable<DiemDanhModel> GetDatabAll()
        {
            return _diemdanhBusiness.GetDataAll();
        }
    }
}
