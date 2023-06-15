using MVC4.DB.Entities;
using MVC4.SERVICE.Infrastructures;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MVC4.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public ActionResult GetCategories()
        {
            var results = _categoryService.GetCategories();
            return new ContentResult
            {
                Content = JsonConvert.SerializeObject(results, Formatting.Indented, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                }),
                ContentType = "application/json",
                ContentEncoding = Encoding.UTF8
            };
        }
        public ActionResult GetCategory(int id)
        {
            var result = _categoryService.GetCategory(id);
            return new ContentResult { Content = JsonConvert.SerializeObject(result), ContentType = "application/json", ContentEncoding = Encoding.UTF8 };
        }
        public ActionResult UpdateCategory(Category category)
        {
            var result = _categoryService.UpdateCategory(category);
            return new ContentResult { Content = JsonConvert.SerializeObject(result), ContentType = "application/json", ContentEncoding = Encoding.UTF8 };
        }
        public ActionResult DeleteCategory(int id)
        {
            try
            {
                var result = _categoryService.DeleteCategory(id);
                return new ContentResult { Content = JsonConvert.SerializeObject(result), ContentType = "application/json", ContentEncoding = Encoding.UTF8 };
            }
            catch (Exception e)
            {
                if (e.ToString().Contains("FK_Product_Category"))
                {
                    throw new Exception("Can't delete category");
                }
                throw new Exception(e.ToString());
            }
        }
        public ActionResult InsertCategory(Category category)
        {
            var result = _categoryService.InsertCategory(category);
            return new ContentResult { Content = JsonConvert.SerializeObject(result), ContentType = "application/json", ContentEncoding = Encoding.UTF8 };
        }
    }
}