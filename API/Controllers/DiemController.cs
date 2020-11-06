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
        public DiemModel CreateUser([FromBody] DiemModel model)
        {
            _diemBusiness.Create(model);
            return model;
        }

        [Route("delete-diem")]
        [HttpPost]
        public IActionResult DeleteUser([FromBody] Dictionary<string, object> formData)
        {
            int id = 0;
            if (formData.Keys.Contains("id") && !string.IsNullOrEmpty(Convert.ToString(formData["id"]))) { id = int.Parse(Convert.ToString(formData["id"])); }
            _diemBusiness.Delete(id);
            return Ok();
        }

        [Route("update-diem")]
        [HttpPost]
        public DiemModel UpdateUser([FromBody] DiemModel model)
        {
            _diemBusiness.Update(model);
            return model;
        }
        [Route("get-by-id/{id}")]
        [HttpGet]
        public DiemModel GetDatabyID(int id)
        {
            return _diemBusiness.GetDatabyID(id);
        }
        [Route("get-all")]
        [HttpGet]
        public IEnumerable<DiemModel> GetDatabAll()
        {
            return _diemBusiness.GetDataAll();
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
                if (formData.Keys.Contains("lop") && !string.IsNullOrEmpty(Convert.ToString(formData["lop"]))) { lop = Convert.ToString(formData["lop"]); }
                string monhoc = "";
                if (formData.Keys.Contains("monhoc") && !string.IsNullOrEmpty(Convert.ToString(formData["monhoc"]))) { monhoc = Convert.ToString(formData["monhoc"]); }
                string buoi = "";
                if (formData.Keys.Contains("buoi") && !string.IsNullOrEmpty(Convert.ToString(formData["buoi"]))) { buoi = Convert.ToString(formData["buoi"]); }
                string ngay = "";
                if (formData.Keys.Contains("ngay") && !string.IsNullOrEmpty(Convert.ToString(formData["ngay"]))) { ngay = Convert.ToString(formData["ngay"]); }
                long total = 0;
                var data = _diemBusiness.Search(page, pageSize, out total, lop, monhoc, buoi, ngay);
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
