using MVC4.DB.Entities;
using MVC4.SERVICE.Infrastructures;
using MVC4.SERVICE.Sessions;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC4.SERVICE.Services
{
    public class CartService : ICartService
    {
        public bool DeleteCart(int id)
        {
            var result = false;
            SessionManager.DoWork(ss =>
            {
                ss.Delete(new Cart { Id = id });
                result = true;
            });
            return result;
        }

        public Cart GetCart(int id)
        {
            var ss = SessionManager.Session;
            var result = ss.Get<Cart>(id);
            return result;
        }

        public IList<Cart> GetCarts()
        {
            var ss = SessionManager.Session;
            var results = ss.Query<Cart>().ToList();
            return results;
        }

        public bool InsertCart(Cart cart)
        {
            var result = false;
            SessionManager.DoWork(ss =>
            {
                ss.Save(cart);
                result = true;
            });
            return result;
        }

        public bool UpdateCart(Cart cart)
        {
            var result = false;
            SessionManager.DoWork(ss =>
            {
                    ss.Update(cart);
                    result = true;
            });
            return result;
        }
    }
}
