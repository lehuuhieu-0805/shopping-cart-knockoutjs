using MVC4.DB.Entities;
using MVC4.SERVICE.Infrastructures;
using MVC4.SERVICE.Sessions;
using NHibernate.Linq;
using NHibernate.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC4.SERVICE.Services
{
    public class CartItemService : ICartItemService
    {
        private readonly ICartService _cartService;
        private readonly IProductService _productService;
        public CartItemService(ICartService cartService, IProductService productService)
        {
            _cartService = cartService;
            _productService = productService;

        }
        public string AddToCart(CartItem cartItem)
        {
            Product product = _productService.GetProduct(cartItem.ProductId);
            if (cartItem.ProductQuantity > product.Quantity)
            {
                return "Quantity of product in stock not enough";
            }
            int cartId = 1;
            bool resultUpdateCart = false;
            bool resultUpdateCartItem = false;
            var cartTemp = new Cart();
            Cart cart = _cartService.GetCart(cartId);
            IList<CartItem> cartItems = this.GetCartItems();
            // if product has existed in cart
            foreach (var item in cartItems)
            {
                if (item.ProductId == cartItem.ProductId)
                {
                    item.ProductQuantity += cartItem.ProductQuantity;
                    // check quantity of products in stock is enough or not?
                    if (item.ProductQuantity > product.Quantity)
                    {
                        return "Quantity of product in stock not enough";
                    }
                    item.TotalPrice += cartItem.TotalPrice;
                    // check quantity product in cart <= 0 to remove product from cart
                    if (item.ProductQuantity <= 0)
                    {
                        resultUpdateCartItem = this.DeleteCartItem(item.Id);
                    } else
                    {
                        resultUpdateCartItem = this.UpdateCartItem(item);
                    }

                    cart.TotalPrice += cartItem.TotalPrice;
                    cart.TotalQuantity += cartItem.ProductQuantity;
                    cartTemp = new Cart
                    {
                        Id = cart.Id,
                        TotalQuantity = cart.TotalQuantity,
                        TotalPrice = cart.TotalPrice,
                    };
                    resultUpdateCart = _cartService.UpdateCart(cartTemp);
                    // success all
                    if (resultUpdateCart && resultUpdateCartItem)
                    {
                        return "success";
                    }
                }
            }
            // if product has not existed in cart
            var resultInsertCartItem = this.InsertCartItem(cartItem);

            cart.TotalQuantity += cartItem.ProductQuantity;
            cart.TotalPrice += cartItem.TotalPrice;
            cartTemp = new Cart
            {
                Id = cart.Id,
                TotalQuantity = cart.TotalQuantity,
                TotalPrice = cart.TotalPrice,
            };
            resultUpdateCart = _cartService.UpdateCart(cartTemp);

            //bool result = false;
            if (resultInsertCartItem && resultUpdateCart)
            {
                return "success";
            };
            return "false";
        }

        public bool DeleteCartItem(int id)
        {
            var result = false;
            SessionManager.DoWork(ss =>
            {
                ss.Delete(new CartItem { Id = id });
                result = true;
            });
            return result;
        }

        public IList<CartItem> FindByCartId(int id)
        {
            var ss = SessionManager.Session;
            var results = ss.Query<CartItem>().Where(c => c.CartId == id).ToList();
            return results;
        }

        public CartItem GetCartItem(int id)
        {
            var ss = SessionManager.Session;
            var result = ss.Get<CartItem>(id);
            return result;
        }

        public IList<CartItem> GetCartItems()
        {
            var ss = SessionManager.Session;
            var results = ss.Query<CartItem>().ToList();
            return results;
        }

        public string IncreaseProductQuantity(int productId)
        {
            var product = _productService.GetProduct(productId);
            CartItem cartItem = new CartItem { CartId = 1, ProductQuantity = 1, TotalPrice = product.Price, ProductId = productId };
            string result = this.AddToCart(cartItem);
            return result;
        }

        public bool InsertCartItem(CartItem cartItem)
        {
            var result = false;
            cartItem.Cart = new Cart { Id = cartItem.CartId };
            cartItem.Product = new Product { Id = cartItem.ProductId };
            SessionManager.DoWork(ss =>
            {
                ss.Save(cartItem);
                result = true;
            });
            return result;
        }

        public string MinusProductQuantity(int productId)
        {
            var product = _productService.GetProduct(productId);
            CartItem cartItem = new CartItem { CartId = 1, ProductQuantity = -1, TotalPrice = -product.Price, ProductId = productId };
            string result = this.AddToCart(cartItem);
            return result;
        }

        public bool UpdateCartItem(CartItem cartItem)
        {
            var result = false;
            cartItem.Cart = new Cart { Id = cartItem.CartId };
            cartItem.Product = new Product { Id = cartItem.ProductId };
            SessionManager.DoWork(ss =>
            {
                ss.Update(cartItem);
                result = true;
            });
            return result;
        }
    }
}
