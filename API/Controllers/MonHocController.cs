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
    public class MonHocController : ControllerBase
    {
        private IMonHocBusiness _monhocBusiness;
        public MonHocController(IMonHocBusiness monhocBusiness)
        {
            _monhocBusiness = monhocBusiness;
        }

        [Route("create-mon-hoc")]
        [HttpPost]
        public MonHocModel CreateCTDiemDanh([FromBody] MonHocModel model)
        {

            return model;
        }
        [Route("get-by-id/{id}")]
        [HttpGet]
        public MonHocModel GetDatabyID(string id)
        {
            return _monhocBusiness.GetDatabyID(id);
        }
        [Route("get-all")]
        [HttpGet]
        public IEnumerable<MonHocModel> GetDatabAll()
        {
            return _monhocBusiness.GetDataAll();
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
                string tenmon = "";
                if (formData.Keys.Contains("tenmon") && !string.IsNullOrEmpty(Convert.ToString(formData["tenmon"]))) { tenmon   = Convert.ToString(formData["tenmon"]); }
                long total = 0;
                var data = _monhocBusiness.Search(page, pageSize, out total, tenmon);
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
