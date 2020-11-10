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
    public class KhachHangController : ControllerBase
    {
        private IKhachHangBLL _customerBusiness;
        public KhachHangController(IKhachHangBLL customerBusiness)
        {
            _customerBusiness = customerBusiness;
        }

        [Route("create-customer")]
        [HttpPost]
        public KhachHang CreateCustomer([FromBody] KhachHang model)
        {
            _customerBusiness.CreateCustomer(model);
            return model;
        }

        [Route("delete-customer")]
        [HttpPost]
        public IActionResult DeleteCustomer([FromBody] Dictionary<string, object> formData)
        {
            string makh = "";
            if (formData.Keys.Contains("makh") && !string.IsNullOrEmpty(Convert.ToString(formData["makh"]))) { makh = Convert.ToString(formData["makh"]); }
            _customerBusiness.Delete(makh);
            return Ok();
        }
        [Route("update-customer")]
        [HttpPost]
        public KhachHang Updatecustomer([FromBody] KhachHang model)
        {

            _customerBusiness.Update(model);
            return model;
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public KhachHang GetDatabyID(string id)
        {
            return _customerBusiness.GetDatabyID(id);
        }

        [Route("search-customer")]
        [HttpPost]
        public ResponseModel Search([FromBody] Dictionary<string, object> formData)
        {
            var response = new ResponseModel();
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string tenkh = "";
                if (formData.Keys.Contains("tenkh") && !string.IsNullOrEmpty(Convert.ToString(formData["tenkh"]))) { tenkh = Convert.ToString(formData["tenkh"]); }
                string email = "";
                if (formData.Keys.Contains("email") && !string.IsNullOrEmpty(Convert.ToString(formData["email"]))) { email = Convert.ToString(formData["email"]); }
                long total = 0;
                var data = _customerBusiness.Search(page, pageSize, out total, email, tenkh);
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