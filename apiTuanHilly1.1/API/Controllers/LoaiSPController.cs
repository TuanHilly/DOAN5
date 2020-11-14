using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiSPController : ControllerBase
    {
        private ILoaiSPBLL _CategoryBusiness;
        public LoaiSPController(ILoaiSPBLL CategoryBusiness)
        {
            _CategoryBusiness = CategoryBusiness;
        }
        // GET: api/<LoaiController>
        [Route("get-category")]
        [HttpGet]
        public IEnumerable<LoaiSP> GetAllCategory()
        {
            return _CategoryBusiness.GetData();
        }

        [Route("delete-category")]
        [HttpPost]
        public IActionResult DeleteCategory([FromBody] Dictionary<string, object> formData)
        {
            string maloai = "";
            if (formData.Keys.Contains("maloai") && !string.IsNullOrEmpty(Convert.ToString(formData["maloai"]))) { maloai = Convert.ToString(formData["maloai"]); }
            _CategoryBusiness.Delete(maloai);
            return Ok();
        }

        [Route("create-category")]
        [HttpPost]
        public LoaiSP CreateCategory([FromBody] LoaiSP model)
        {
            model.maloai = Guid.NewGuid().ToString();
            model.parent_maloai = "10";
            _CategoryBusiness.Create(model);
            return model;
        }

        [Route("update-category")]
        [HttpPost]
        public LoaiSP UpdateCategory([FromBody] LoaiSP model)
        {

            _CategoryBusiness.Update(model);
            return model;
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public LoaiSP GetDatabyID(string id)
        {
            return _CategoryBusiness.GetDatabyID(id);
        }

        [Route("search-category")]
        [HttpPost]
        public ResponseModel Search([FromBody] Dictionary<string, object> formData)
        {
            var response = new ResponseModel();
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string tenloai = "";
                if (formData.Keys.Contains("tenloai") && !string.IsNullOrEmpty(Convert.ToString(formData["tenloai"]))) { tenloai = Convert.ToString(formData["tenloai"]); }
                long total = 0;
                var data = _CategoryBusiness.Search(page, pageSize, out total, tenloai);
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