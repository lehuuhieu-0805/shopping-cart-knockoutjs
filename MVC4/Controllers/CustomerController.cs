using MVC4.DB.Entities;
using MVC4.SERVICE.Infrastructures;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MVC4.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public ActionResult GetCustomers()
        {
            var results = _customerService.GetCustomers();
            return new ContentResult { Content = JsonConvert.SerializeObject(results), ContentType = "application/json", ContentEncoding = Encoding.UTF8 };
        }
        public ActionResult GetCustomer(int id)
        {
            var results = _customerService.GetCustomer(id);
            return new ContentResult { Content = JsonConvert.SerializeObject(results), ContentType = "application/json", ContentEncoding = Encoding.UTF8 };
        }
        public ActionResult InsertCustomer(Customer customer)
        {
            var results = _customerService.InsertCustomer(customer);
            return new ContentResult { Content = JsonConvert.SerializeObject(results), ContentType = "application/json", ContentEncoding = Encoding.UTF8 };
        }
        public ActionResult UpdateCustomer(Customer customer)
        {
            var results = _customerService.UpdateCustomer(customer);
            return new ContentResult { Content = JsonConvert.SerializeObject(results), ContentType = "application/json", ContentEncoding = Encoding.UTF8 };
        }
        public ActionResult DeleteCustomer(int id)
        {
            var results = _customerService.DeleteCustomer(id);
            return new ContentResult { Content = JsonConvert.SerializeObject(results), ContentType = "application/json", ContentEncoding = Encoding.UTF8 };
        }
    }
}