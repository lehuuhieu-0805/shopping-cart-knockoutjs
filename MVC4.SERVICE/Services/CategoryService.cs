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
    public class CategoryService : ICategoryService
    {
        public bool DeleteCategory(int id)
        {
            var result = false;
            SessionManager.DoWork(ss =>
            {
                ss.Delete(new Category { Id = id });
                result = true;
            });
            return result;
        }

        public List<Category> GetCategories()
        {
            var ss = SessionManager.Session;
            var result = ss.Query<Category>().ToList();
            return result;
        }

        public Category GetCategory(int id)
        {
            var ss = SessionManager.Session;
            var result = ss.Get<Category>(id);
            return result;
        }

        public bool InsertCategory(Category category)
        {
            var result = false;
            SessionManager.DoWork(ss =>
            {
                ss.Save(category);
                result = true;
            });
            return result;
        }

        public bool UpdateCategory(Category category)
        {
            var result = false;
            SessionManager.DoWork(ss =>
            {
                ss.Update(category);
                result = true;
            });
            return result;
        }
    }
}
