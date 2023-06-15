using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC4.DB.Entities
{
    public class Cart
    {
        public virtual int Id { get; set; }
        public virtual int TotalQuantity { get; set; }
        public virtual float TotalPrice { get; set; }
        public virtual IList<CartItem> CartItems { get; set; }
    }
}
