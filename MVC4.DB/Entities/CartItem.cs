using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC4.DB.Entities
{
    public class CartItem
    {
        public virtual int Id { get; set; }
        public virtual int CartId { get; set; }
        public virtual int ProductId { get; set; }
        public virtual int ProductQuantity { get; set; }
        public virtual float TotalPrice { get; set; }
        public virtual Cart Cart { get; set; }
        public virtual Product Product { get; set; }
    }
}
