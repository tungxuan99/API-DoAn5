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
        public HocSinhModel CreateUser([FromBody] HocSinhModel model)
        {
            _hocsinhBusiness.Create(model);
            return model;
        }

        [Route("delete-hoc-sinh")]
        [HttpPost]
        public IActionResult DeleteUser([FromBody] Dictionary<string, object> formData)
        {
            int id = 0;
            if (formData.Keys.Contains("id") && !string.IsNullOrEmpty(Convert.ToString(formData["id"]))) { id = int.Parse(Convert.ToString(formData["id"])); }
            _hocsinhBusiness.Delete(id);
            return Ok();
        }

        [Route("update-hoc-sinh")]
        [HttpPost]
        public HocSinhModel UpdateUser([FromBody] HocSinhModel model)
        {
            _hocsinhBusiness.Update(model);
            return model;
        }
        [Route("get-by-id/{id}")]
        [HttpGet]
        public HocSinhModel GetDatabyID(int id)
        {
            return _hocsinhBusiness.GetDatabyID(id);
        }
        [Route("get-by-lop/{malop}")]
        [HttpGet]
        public IEnumerable<HocSinhModel> GetDatabyLop(string malop)
        {
            return _hocsinhBusiness.GetDataLop(malop);
        }
        [Route("get-by-ten-mahs/{Search}")]
        [HttpGet]
        public IEnumerable<HocSinhModel> GetDataDiemHK(string Search)
        {
            return _hocsinhBusiness.GetDataDiemHK(Search);
        }
        [Route("get-all")]
        [HttpGet]
        public IEnumerable<HocSinhModel> GetDatabAll()
        {
            return _hocsinhBusiness.GetDataAll();
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
                string malophoc = "";
                string khoihoc = "";
                if (formData.Keys.Contains("hoten") && !string.IsNullOrEmpty(Convert.ToString(formData["hoten"]))) { hoten = Convert.ToString(formData["hoten"]); }
                if (formData.Keys.Contains("malophoc") && !string.IsNullOrEmpty(Convert.ToString(formData["malophoc"]))) { malophoc = Convert.ToString(formData["malophoc"]); }
                if (formData.Keys.Contains("khoihoc") && !string.IsNullOrEmpty(Convert.ToString(formData["khoihoc"]))) { khoihoc = Convert.ToString(formData["khoihoc"]); }
                long total = 0;
                var data = _hocsinhBusiness.Search(page, pageSize, out total, hoten, malophoc, khoihoc);
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
