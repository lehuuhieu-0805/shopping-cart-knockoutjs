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
    public class LambdaService : ILambdaService
    {
        public Dictionary<string, dynamic> LambdaExample()
        {

            var ss = SessionManager.Session;
            var _customer = ss.Query<Customer>();
            var _order = ss.Query<Order>();
            // select
            var _select = _customer
                .Select(p => new { p.Id, p.FirstName, p.LastName })
                .AsEnumerable();
            
            // where
            var _where = _customer
                .Where(p => p.Id == 1)
                .AsEnumerable();
            
            // contains
            var ids = new int[] { 1, 2 };
            var _contains = _customer
                .Where(p => ids.Contains(p.Id))
                .AsEnumerable();
            
            // first -- error if not found item.
            var _first = _customer
                //.First(p => p.Id == 0); error
                .First(p => p.Id == 1);
            
            // first or default -- null if not found item.
            var _first_or_default = _customer
                .SingleOrDefault(p => p.Id == 0);
            
            // single -- error if not found item or found multiple items
            var _single = _customer
                // .Single(p => p.Id == 0); error
                .Single(p => p.Id == 1);
            
            // single or default -- null if not found item and error if found multiple items
            var _single_or_default = _customer
               .SingleOrDefault(p => p.Id == 0);
            
            // group
            var _group = _order
                .GroupBy(p => p.CustomerId) // sum, max, min, first, last, ...
                .Select(grp => new { CustomerId = grp.Key, TotalAmount = grp.Sum(p => p.TotalAmount) })
                .AsEnumerable();
            
            // join
            var _join = _customer
                .Join(
                    _order,
                    cus => cus.Id,
                    ord => ord.CustomerId,
                    (cus, ord) => new { cus, ord }
                )
                .AsEnumerable();
            
            // left jion
            var _left_join = _customer
                .Select(p => new
                {
                    p.Id,
                    p.FirstName,
                    p.LastName,
                    Order = _order.FirstOrDefault(ord => ord.CustomerId == p.Id)
                })
                .AsEnumerable();
            var result = new Dictionary<string, dynamic>
            {
                {"Select", _select },
                {"Where", _where },
                {"Contains", _contains },
                {"First", _first },
                {"FirstOrDefault", _first_or_default },
                {"Single", _single },
                {"SingleOrDefault", _single_or_default },
                {"Group", _group },
                {"Join", _join },
                {"LeftJoin", _left_join },
            };

            return result;
        }
    }
}
