using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        private ISanPhamBLL _productBusiness;
        private string _path;
        public SanPhamController(ISanPhamBLL productBusiness)
        {
            _productBusiness = productBusiness;
        }

        [Route("create-product")]
        [HttpPost]
        public SanPham CreateProduct([FromBody] SanPham model)
        {
            if (model.anh != null)
            {
                var arrData = model.anh.Split(';');
                if (arrData.Length == 3)
                {
                    var savePath = $@"{arrData[0]}";
                    model.anh = $"{savePath}";
                    SaveFileFromBase64String(savePath, arrData[2]);
                }
            }
            _productBusiness.Create(model);
            return model;
        }

        [Route("update-product")]
        [HttpPost]
        public SanPham UpdateProduct([FromBody] SanPham model)
        {
            if (model.anh != null)
            {
                var arrData = model.anh.Split(';');
                if (arrData.Length == 3)
                {
                    var savePath = $@"{arrData[0]}";
                    model.anh = $"{savePath}";
                    SaveFileFromBase64String(savePath, arrData[2]);
                }
            }
            _productBusiness.Update(model);
            return model;
        }

        [Route("search-product")]
        [HttpPost]
        public ResponseModel Search([FromBody] Dictionary<string, object> formData)
        {
            var response = new ResponseModel();
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string tensp = "";
                if (formData.Keys.Contains("tensp") && !string.IsNullOrEmpty(Convert.ToString(formData["tensp"]))) { tensp = Convert.ToString(formData["tensp"]); }
                decimal dongia = 0;
                if (formData.Keys.Contains("dongia") && (formData["dongia"]) != null) { dongia = Convert.ToDecimal(formData["dongia"]); }
                long total = 0;
                var data = _productBusiness.Search(page, pageSize, out total, tensp, dongia);
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

        [Route("delete-product")]
        [HttpPost]
        public IActionResult DeleteProduct([FromBody] Dictionary<string, object> formData)
        {
            string masp = "";
            if (formData.Keys.Contains("masp") && !string.IsNullOrEmpty(Convert.ToString(formData["masp"]))) { masp = Convert.ToString(formData["masp"]); }
            _productBusiness.Delete(masp);
            return Ok();
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public SanPham GetDatabyID(int id)
        {
            return _productBusiness.GetDatabyID(id);
        }
        [Route("get-all/{page_index}/{page_size}")]
        [HttpGet]
        public IEnumerable<SanPham> GetDatabAll(int page_index, int page_size)
        {
            long total = 0;
            var kq = _productBusiness.GetDataAll(page_index, page_size, out total);
            foreach (var item in kq)
            {
                item.total = total;
            }
            return kq;
        }

        [Route("get-new")]
        [HttpGet]
        public IEnumerable<SanPham> GetDataNew()
        {
            return _productBusiness.GetDataNew();
        }
        [Route("get-status")]
        [HttpGet]
        public IEnumerable<SanPham> GetDataStatus()
        {
            return _productBusiness.GetDataStatus();
        }
        [Route("search-category")]
        [HttpPost]
        public ResponseModel SearchCategory([FromBody] Dictionary<string, object> formData)
        {
            var response = new ResponseModel();
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string maloai = "";
                if (formData.Keys.Contains("maloai") && !string.IsNullOrEmpty(Convert.ToString(formData["maloai"]))) { maloai = Convert.ToString(formData["maloai"]); }
                long total = 0;
                var data = _productBusiness.SearchCategory(page, pageSize, out total, maloai);
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

        [Route("search-brand")]
        [HttpPost]
        public ResponseModel SearchBrand([FromBody] Dictionary<string, object> formData)
        {
            var response = new ResponseModel();
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string mathuonghieu = "";
                if (formData.Keys.Contains("mathuonghieu") && !string.IsNullOrEmpty(Convert.ToString(formData["mathuonghieu"]))) { mathuonghieu = Convert.ToString(formData["mathuonghieu"]); }
                long total = 0;
                var data = _productBusiness.SearchBrand(page, pageSize, out total, mathuonghieu);
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
        public string SaveFileFromBase64String(string RelativePathFileName, string dataFromBase64String)
        {
            if (dataFromBase64String.Contains("base64,"))
            {
                dataFromBase64String = dataFromBase64String.Substring(dataFromBase64String.IndexOf("base64,", 0) + 7);
            }
            return WriteFileToAuthAccessFolder(RelativePathFileName, dataFromBase64String);
        }
        public string WriteFileToAuthAccessFolder(string RelativePathFileName, string base64StringData)
        {
            try
            {
                string result = "";
                string serverRootPathFolder = _path;
                string fullPathFile = $@"{serverRootPathFolder}\{RelativePathFileName}";
                string fullPathFolder = System.IO.Path.GetDirectoryName(fullPathFile);
                if (!Directory.Exists(fullPathFolder))
                    Directory.CreateDirectory(fullPathFolder);
                System.IO.File.WriteAllBytes(fullPathFile, Convert.FromBase64String(base64StringData));
                return result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}