using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC4.DB.Entities
{
    public class Product
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual float Price { get; set; }
        public virtual int Quantity { get; set; }
        public virtual int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual IList<CartItem> CartItems { get; set; }
    }
}
