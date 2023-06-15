using MVC4.DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC4.SERVICE.Infrastructures
{
    public interface IProductService
    {
        IList<Product> GetProducts();
        Product GetProduct(int id);
        bool InsertProduct(Product product);
        bool UpdateProduct(Product product);
        bool DeleteProduct(int id);
        IList<Product> FindByCategoryId(int id);
        IList<Product> Paging(int page, int pageSize);
        IList<Product> SearchByName(string name);
        IList<Product> SearchByNameWithPaging(string name, int page, int pageSize);
    }
}
