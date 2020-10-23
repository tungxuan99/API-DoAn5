﻿using System;
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

        [Route("create-tin-tuc")]
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
        public ResponseModel Search([FromBody] Dictionary<string, object> formData)
        {
            var response = new ResponseModel();
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string tieude = "";
                if (formData.Keys.Contains("tieude") && !string.IsNullOrEmpty(Convert.ToString(formData["tenmon"]))) { tieude = Convert.ToString(formData["tieude"]); }
                long total = 0;
                var data = _tintucBusiness.Search(page, pageSize, out total, tieude);
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
