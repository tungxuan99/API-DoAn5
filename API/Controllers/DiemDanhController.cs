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
        public DiemDanhModel CreateUser([FromBody] DiemDanhModel model)
        {
            _diemdanhBusiness.Create(model);
            return model;
        }

        [Route("delete-diem-danh")]
        [HttpPost]
        public IActionResult DeleteUser([FromBody] Dictionary<string, object> formData)
        {
            int id = 0;
            if (formData.Keys.Contains("id") && !string.IsNullOrEmpty(Convert.ToString(formData["id"]))) { id = int.Parse(Convert.ToString(formData["id"])); }
            _diemdanhBusiness.Delete(id);
            return Ok();
        }

        [Route("update-diem-danh")]
        [HttpPost]
        public DiemDanhModel UpdateUser([FromBody] DiemDanhModel model)
        {
            _diemdanhBusiness.Update(model);
            return model;
        }
        [Route("get-by-id/{id}")]
        [HttpGet]
        public DiemDanhModel GetDatabyID(int id)
        {
            return _diemdanhBusiness.GetDatabyID(id);
        }
        [Route("get-all")]
        [HttpGet]
        public IEnumerable<DiemDanhModel> GetDatabAll()
        {
            return _diemdanhBusiness.GetDataAll();
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
                string mon = "";
                if (formData.Keys.Contains("mon") && !string.IsNullOrEmpty(Convert.ToString(formData["mon"]))) { mon = Convert.ToString(formData["mon"]); }
                string buoi = "";
                if (formData.Keys.Contains("buoi") && !string.IsNullOrEmpty(Convert.ToString(formData["buoi"]))) { buoi = Convert.ToString(formData["buoi"]); }
                string ngay = "";
                if (formData.Keys.Contains("ngay") && !string.IsNullOrEmpty(Convert.ToString(formData["ngay"]))) { ngay = Convert.ToString(formData["ngay"]); }
                long total = 0;
                var data = _diemdanhBusiness.Search(page, pageSize, out total, mon, buoi, ngay);
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
