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
    public class CustomerService : ICustomerService
    {
        public List<Customer> GetCustomers()
        {
            var ss = SessionManager.Session;
            var results = ss.Query<Customer>()               
                .OrderByDescending(p => p.Id)
                //.Count(p => Convert.ToBoolean(p.Id))
                //.ThenBy(p => p.Id)
                .ToList();
            //var totalrow = ss.Query<Customer>().Count();

            //var results = new Dictionary<string, dynamic>
            //{
            //    {"TotalRow", totalrow },
            //    {"ListCustomer", listCus },
                
            //};
            return results;
        }
        public Customer GetCustomer(int id)
        {
            var ss = SessionManager.Session;
            var result = ss.Get<Customer>(id);
            return result;
        }

        public bool InsertCustomer(Customer customer)
        {
            var result = false;
            SessionManager.DoWork(ss =>
            {
                customer.CreatedDate = DateTime.Now;
                ss.Save(customer);
                result = true;
            });
            return result;
        }

        public bool UpdateCustomer(Customer customer)
        {
            var result = false;
            SessionManager.DoWork(ss =>
            {
                customer.CreatedDate = DateTime.Now;
                ss.Update(customer);
                result = true;
            });
            return result;
        }
        public bool DeleteCustomer(int id)
        {
            var result = false;
            SessionManager.DoWork(ss =>
            {
                ss.Delete(new Customer { Id = id });
                result = true;
            });
            return result;
        }

    }
}
