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
    public class LopHocController : ControllerBase
    {
        private ILopHocBusiness _lophocBusiness;
        public LopHocController(ILopHocBusiness lophocBusiness)
        {
            _lophocBusiness = lophocBusiness;
        }

        [Route("delete-lop-hoc")]
        [HttpPost]
        public IActionResult DeleteUser([FromBody] Dictionary<string, object> formData)
        {
            string malop = "";
            if (formData.Keys.Contains("id") && !string.IsNullOrEmpty(Convert.ToString(formData["id"]))) { malop = Convert.ToString(formData["id"]); }
            _lophocBusiness.Delete(malop);
            return Ok();
        }

        [Route("create-lop-hoc")]
        [HttpPost]
        public LopHocModel CreateUser([FromBody] LopHocModel model)
        {
            _lophocBusiness.Create(model);
            return model;
        }

        [Route("update-lop-hoc")]
        [HttpPost]
        public LopHocModel UpdateUser([FromBody] LopHocModel model)
        {
            _lophocBusiness.Update(model);
            return model;
        }
        [Route("get-by-id/{id}")]
        [HttpGet]
        public LopHocModel GetDatabyID(string id)
        {
            return _lophocBusiness.GetDatabyID(id);
        }
        [Route("get-all")]
        [HttpGet]
        public IEnumerable<LopHocModel> GetDatabAll()
        {
            return _lophocBusiness.GetDataAll();
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
                string tenlop = "";
                if (formData.Keys.Contains("tenlop") && !string.IsNullOrEmpty(Convert.ToString(formData["tenlop"]))) { tenlop = Convert.ToString(formData["tenlop"]); }
                long total = 0;
                var data = _lophocBusiness.Search(page, pageSize, out total, tenlop);
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
