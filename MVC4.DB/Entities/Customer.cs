using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC4.DB.Entities
{
    public class Customer
    {
        public virtual int Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string City { get; set; }
        public virtual string Country { get; set; }
        public virtual string Phone { get; set; }
        public virtual DateTime CreatedDate { get; set; }

    }
}
