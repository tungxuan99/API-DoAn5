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
        [Route("search")]
        [HttpPost]
        public ResponseModel Search([FromBody] Dictionary<string, object> formData)
        {
            var response = new ResponseModel();
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string lop = "";
                if (formData.Keys.Contains("lop") && !string.IsNullOrEmpty(Convert.ToString(formData["hoten"]))) { lop = Convert.ToString(formData["lop"]); }
                string namhoc = "";
                if (formData.Keys.Contains("namhoc") && !string.IsNullOrEmpty(Convert.ToString(formData["namhoc"]))) { namhoc = Convert.ToString(formData["namhoc"]); }
                string kyhoc = "";
                if (formData.Keys.Contains("kyhoc") && !string.IsNullOrEmpty(Convert.ToString(formData["kyhoc"]))) { kyhoc = Convert.ToString(formData["kyhoc"]); }
                long total = 0;
                string buoi = "";
                if (formData.Keys.Contains("buoi") && !string.IsNullOrEmpty(Convert.ToString(formData["buoi"]))) { buoi = Convert.ToString(formData["buoi"]); }
                var data = _ctdiemdanhBusiness.Search(page, pageSize, out total, lop, namhoc, kyhoc, buoi);
                response.TotalItems = total;
                response.Data = data;
                response.Page = page;
                response.PageSize = pageSize;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return response;
        }
    }
}
