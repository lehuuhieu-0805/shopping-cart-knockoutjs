using MVC4.DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC4.SERVICE.Infrastructures
{
    public interface ICartService
    {
        IList<Cart> GetCarts();
        Cart GetCart(int id);
        bool InsertCart(Cart cart);
        bool UpdateCart(Cart cart);
        bool DeleteCart(int id);
    }
}
