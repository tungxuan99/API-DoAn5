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

        [Route("delete-giao-vien")]
        [HttpPost]
        public IActionResult DeleteUser([FromBody] Dictionary<string, object> formData)
        {
            string malop = "";
            if (formData.Keys.Contains("id") && !string.IsNullOrEmpty(Convert.ToString(formData["id"]))) { malop = Convert.ToString(formData["id"]); }
            _giaovienBusiness.Delete(malop);
            return Ok();
        }

        [Route("update-giao-vien")]
        [HttpPost]
        public GiaoVienModel UpdateUser([FromBody] GiaoVienModel model)
        {
            _giaovienBusiness.Update(model);
            return model;
        }

        [Route("create-giao-vien")]
        [HttpPost]
        public GiaoVienModel CreateUser([FromBody] GiaoVienModel model)
        {
            _giaovienBusiness.Create(model);
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
        [Route("search")]
        [HttpPost]
        public ResponseModel Search([FromBody] Dictionary<string, object> formData)
        {
            var response = new ResponseModel();
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string hoten = "";
                if (formData.Keys.Contains("hoten") && !string.IsNullOrEmpty(Convert.ToString(formData["hoten"]))) { hoten = Convert.ToString(formData["hoten"]); }
                
                long total = 0;
                var data = _giaovienBusiness.Search(page, pageSize, out total, hoten);
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
