using MVC4.DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC4.SERVICE.Infrastructures
{
    public interface ICategoryService
    {
        List<Category> GetCategories();
        Category GetCategory(int id);
        bool InsertCategory(Category category);
        bool UpdateCategory(Category category);
        bool DeleteCategory(int id);
    }
}
