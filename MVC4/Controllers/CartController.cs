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
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }
        public ActionResult GetCarts()
        {
            var results = _cartService.GetCarts();
            return new ContentResult
            {
                Content = JsonConvert.SerializeObject(results, Formatting.Indented, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    ContractResolver = new NHibernateContractResolver()
                }),
                ContentType = "application/json",
                ContentEncoding = Encoding.UTF8
            };
        }
        public ActionResult GetCart(int id)
        {
            var result = _cartService.GetCart(id);
            return new ContentResult
            {
                Content = JsonConvert.SerializeObject(result, Formatting.Indented, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    ContractResolver = new NHibernateContractResolver()
                }),
                ContentType = "application/json",
                ContentEncoding = Encoding.UTF8,
            };
        }
        public ActionResult UpdateCart(Cart cart)
        {
            var result = _cartService.UpdateCart(cart);
            return new ContentResult { Content = JsonConvert.SerializeObject(result), ContentType = "application/json", ContentEncoding = Encoding.UTF8 };
        }
        public ActionResult DeleteCart(int id)
        {
            var result = _cartService.DeleteCart(id);
            return new ContentResult { Content = JsonConvert.SerializeObject(result), ContentType = "application/json", ContentEncoding = Encoding.UTF8 };
        }
        public ActionResult InsertCart(Cart cart)
        {
            var result = _cartService.InsertCart(cart);
            return new ContentResult { Content = JsonConvert.SerializeObject(result), ContentType = "application/json", ContentEncoding = Encoding.UTF8 };
        }
    }
}