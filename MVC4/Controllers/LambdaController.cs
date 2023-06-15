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
    public class LambdaController : Controller
    {
        private readonly ILambdaService _lambdaService;
        public LambdaController(ILambdaService lambdaService)
        {
            _lambdaService = lambdaService;
        }
        public ActionResult LambdaExample()
        {
            var result = _lambdaService.LambdaExample();
            return new ContentResult { Content = JsonConvert.SerializeObject(result), ContentType = "application/json", ContentEncoding = Encoding.UTF8 };
        }
    }
}