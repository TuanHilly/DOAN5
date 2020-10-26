using System;
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
    public class CustomerController : ControllerBase
    {
        private ICustomerBLL _customerBLL;
        public CustomerController(ICustomerBLL customerBLL)
        {
            _customerBLL = customerBLL;
        }
         
        [Route("create-item")]
        [HttpPost]
        public CustomerModel CreateItem([FromBody] CustomerModel model)
        {
            _customerBLL.Create(model);
            return model;
        } 
    }
}
