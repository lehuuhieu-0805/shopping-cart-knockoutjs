using MVC4.DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC4.SERVICE.Infrastructures
{
    public interface ICartItemService
    {
        IList<CartItem> GetCartItems();
        CartItem GetCartItem(int id);
        bool InsertCartItem(CartItem cartItem);
        bool DeleteCartItem(int id);
        bool UpdateCartItem(CartItem cartItem);
        IList<CartItem> FindByCartId(int id);
        string AddToCart(CartItem cartItem);
        string IncreaseProductQuantity(int productId);
        string MinusProductQuantity(int productId);
    }
}
