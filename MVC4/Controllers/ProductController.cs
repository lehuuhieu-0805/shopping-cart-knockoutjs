using MVC4.DB.Entities;
using MVC4.nhibernate;
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
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public ActionResult GetProducts()
        {
            var results = _productService.GetProducts();
            return new ContentResult
            {
                Content = JsonConvert.SerializeObject(results, Formatting.Indented, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    ContractResolver = new NHibernateContractResolver(),
                }),
                ContentType = "application/json",
                ContentEncoding = Encoding.UTF8
            };
        }
        public ActionResult GetProduct(int id)
        {
            var results = _productService.GetProduct(id);
            return new ContentResult { Content = JsonConvert.SerializeObject(results), ContentType = "application/json", ContentEncoding = Encoding.UTF8 };
        }
        public ActionResult UpdateProduct(Product product)
        {
            var results = _productService.UpdateProduct(product);
            return new ContentResult { Content = JsonConvert.SerializeObject(results), ContentType = "application/json", ContentEncoding = Encoding.UTF8 };
        }
        public ActionResult DeleteProduct(int id)
        {
            var results = _productService.DeleteProduct(id);
            return new ContentResult { Content = JsonConvert.SerializeObject(results), ContentType = "application/json", ContentEncoding = Encoding.UTF8 };
        }
        public ActionResult InsertProduct(Product product)
        {
            var results = _productService.InsertProduct(product);
            return new ContentResult { Content = JsonConvert.SerializeObject(results), ContentType = "application/json", ContentEncoding = Encoding.UTF8 };
        }
        public ActionResult FindByCategoryId(int id)
        {
            var results = _productService.FindByCategoryId(id);
            return new ContentResult
            {
                Content = JsonConvert.SerializeObject(results, Formatting.Indented, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    ContractResolver = new NHibernateContractResolver(),
                }),
                ContentType = "application/json",
                ContentEncoding = Encoding.UTF8
            };
        }
        public ActionResult Paging(int page, int pageSize)
        {
            var results = _productService.Paging(page, pageSize);
            return new ContentResult
            {
                Content = JsonConvert.SerializeObject(results, Formatting.Indented, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    ContractResolver = new NHibernateContractResolver(),
                }),
                ContentType = "application/json",
                ContentEncoding = Encoding.UTF8
            };
        }
        public ActionResult SearchByName(string name)
        {
            var results = _productService.SearchByName(name);
            return new ContentResult
            {
                Content = JsonConvert.SerializeObject(results, Formatting.Indented, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    ContractResolver = new NHibernateContractResolver(),
                }),
                ContentType = "application/json",
                ContentEncoding = Encoding.UTF8
            };
        }
        public ActionResult SearchByNameWithPaging(string name, int page = 1, int pageSize = 5)
        {
            var results = _productService.SearchByNameWithPaging(name, page, pageSize);
            return new ContentResult
            {
                Content = JsonConvert.SerializeObject(results, Formatting.Indented, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    ContractResolver = new NHibernateContractResolver(),
                }),
                ContentType = "application/json",
                ContentEncoding = Encoding.UTF8
            };
        }
    }
}