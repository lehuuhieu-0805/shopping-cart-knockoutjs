using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC4.DB.Entities
{
    public class Order
    {
        public virtual int Id { get; set; }
        public virtual DateTime OrderDate { get; set; }
        public virtual string OrderNumber { get; set; }
        public virtual int CustomerId { get; set; }
        public virtual decimal TotalAmount { get; set; }
    }
}
