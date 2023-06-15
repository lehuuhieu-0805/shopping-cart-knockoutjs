using MVC4.DB.Entities;
using MVC4.nhibernate;
using MVC4.SERVICE.Infrastructures;
using MVC4.SERVICE.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MVC4.Controllers
{
    public class CartItemController : Controller
    {
        private readonly ICartItemService _cartItemService;
        public CartItemController(ICartItemService cartItemService)
        {
            _cartItemService = cartItemService;
        }
        public ActionResult GetCartItems()
        {
            var results = _cartItemService.GetCartItems();
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
        public ActionResult GetCartItem(int id)
        {
            var results = _cartItemService.GetCartItem(id);
            return new ContentResult { Content = JsonConvert.SerializeObject(results), ContentType = "application/json", ContentEncoding = Encoding.UTF8 };
        }
        public ActionResult UpdateCartItem(CartItem cartItem)
        {
            var results = _cartItemService.UpdateCartItem(cartItem);
            return new ContentResult { Content = JsonConvert.SerializeObject(results), ContentType = "application/json", ContentEncoding = Encoding.UTF8 };
        }
        public ActionResult DeleteCartItem(int id)
        {
            var results = _cartItemService.DeleteCartItem(id);
            return new ContentResult { Content = JsonConvert.SerializeObject(results), ContentType = "application/json", ContentEncoding = Encoding.UTF8 };
        }
        public ActionResult InsertCartItem(CartItem cartItem)
        {
            var results = _cartItemService.InsertCartItem(cartItem);
            return new ContentResult { Content = JsonConvert.SerializeObject(results), ContentType = "application/json", ContentEncoding = Encoding.UTF8 };
        }
        public ActionResult FindByCartId(int id)
        {
            var results = _cartItemService.FindByCartId(id);
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
        public ActionResult AddToCart(CartItem cartItem)
        {
            string result = _cartItemService.AddToCart(cartItem);

            return new ContentResult
            {
                Content = JsonConvert.SerializeObject(result),
                ContentType = "application/json",
                ContentEncoding = Encoding.UTF8
            };
        }
        public ActionResult IncreaseProductQuantity(int productId)
        {
            var result = _cartItemService.IncreaseProductQuantity(productId);
            return new ContentResult
            {
                Content = JsonConvert.SerializeObject(result),
                ContentType = "application/json",
                ContentEncoding = Encoding.UTF8
            };
        }
        public ActionResult MinusProductQuantity(int productId)
        {
            var result = _cartItemService.MinusProductQuantity(productId);
            return new ContentResult
            {
                Content = JsonConvert.SerializeObject(result),
                ContentType = "application/json",
                ContentEncoding = Encoding.UTF8
            };
        }
    }
}