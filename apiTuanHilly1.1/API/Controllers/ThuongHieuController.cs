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
    public class ThuongHieuController : ControllerBase
    {
        // GET: api/<ThuongHieuController>
        private IThuongHieuBLL _BrandBusiness;
        private string _path;
        public ThuongHieuController(IThuongHieuBLL BrandBusiness)
        {
            _BrandBusiness = BrandBusiness;
        }

        [Route("get-brand")]
        [HttpGet]
        public IEnumerable<ThuongHieu> GetAllBrand()
        {
            return _BrandBusiness.GetData();
        }

        [Route("delete-brand")]
        [HttpPost]
        public IActionResult DeleteBrand([FromBody] Dictionary<string, object> formData)
        {
            string mathuonghieu = "";
            if (formData.Keys.Contains("mathuonghieu") && !string.IsNullOrEmpty(Convert.ToString(formData["mathuonghieu"]))) { mathuonghieu = Convert.ToString(formData["mathuonghieu"]); }
            _BrandBusiness.Delete(mathuonghieu);
            return Ok();
        }

        [Route("create-brand")]
        [HttpPost]
        public ThuongHieu CreateBrand([FromBody] ThuongHieu model)
        {
            model.mathuonghieu = Guid.NewGuid().ToString();
            model.parent_mathuonghieu = "1";
            _BrandBusiness.Create(model);
            return model;
        }

        [Route("update-brand")]
        [HttpPost]
        public ThuongHieu UpdateBrand([FromBody] ThuongHieu model)
        {

            _BrandBusiness.Update(model);
            return model;
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public ThuongHieu GetDatabyID(string id)
        {
            return _BrandBusiness.GetDatabyID(id);
        }

        [Route("search-brand")]
        [HttpPost]
        public ResponseModel Search([FromBody] Dictionary<string, object> formData)
        {
            var response = new ResponseModel();
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string tenthuonghieu = "";
                if (formData.Keys.Contains("tenthuonghieu") && !string.IsNullOrEmpty(Convert.ToString(formData["tenthuonghieu"]))) { tenthuonghieu = Convert.ToString(formData["tenthuonghieu"]); }
                long total = 0;
                var data = _BrandBusiness.Search(page, pageSize, out total, tenthuonghieu);
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