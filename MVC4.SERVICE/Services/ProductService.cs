using MVC4.DB.Entities;
using MVC4.SERVICE.Infrastructures;
using MVC4.SERVICE.Sessions;
using NHibernate.Criterion;
using NHibernate.Linq;
using Remotion.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC4.SERVICE.Services
{
    public class ProductService : IProductService
    {
        public bool DeleteProduct(int id)
        {
            var result = false;
            SessionManager.DoWork(ss =>
            {
                ss.Delete(new Product { Id = id });
                result = true;
            });
            return result;
        }

        public Product GetProduct(int id)
        {
            var ss = SessionManager.Session;
            var result = ss.Get<Product>(id);
            return result;
        }

        public IList<Product> GetProducts()
        {
            var ss = SessionManager.Session;
            var results = ss.Query<Product>()
                .ToList();

            return results;
        }

        public bool InsertProduct(Product product)
        {
            var result = false;
            product.Category = new Category { Id = product.CategoryId };
            SessionManager.DoWork(ss =>
            {
                ss.Save(product);
                result = true;
            });
            return result;
        }

        public bool UpdateProduct(Product product)
        {
            var result = false;
            product.Category = new Category { Id = product.CategoryId };
            SessionManager.DoWork(ss =>
            {
                ss.Update(product);
                result = true;
            });
            return result;
        }

        public IList<Product> FindByCategoryId(int id)
        {
            var ss = SessionManager.Session;
            var results = ss.Query<Product>().Where(p => p.CategoryId == id).ToList();
            return results;
        }

        public IList<Product> Paging(int page, int pageSize)
        {
            var ss = SessionManager.Session;
            var result = ss.QueryOver<Product>().Skip((page - 1) * pageSize).Take(pageSize).List();

            return result;
        }

        public IList<Product> SearchByName(string name)
        {
            var ss = SessionManager.Session;
            var results = ss.QueryOver<Product>().Where(x => x.Name.IsLike(name, MatchMode.Anywhere)).List();
            return results;
        }

        public IList<Product> SearchByNameWithPaging(string name, int page, int pageSize)
        {
            var ss = SessionManager.Session;
            var results = ss.QueryOver<Product>().Where(x => x.Name.IsLike(name, MatchMode.Anywhere)).Skip((page - 1) * pageSize).Take(pageSize).List();
            return results;
        }
    }
}
