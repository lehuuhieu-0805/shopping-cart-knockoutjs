using MVC4.nhibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MVC4
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            // Setup ApplicationResgister
            AplicationRegister.Register(GlobalConfiguration.Configuration);
            AplicationRegister.RegisterGlobalFilters(GlobalFilters.Filters);
            AplicationRegister.RegisterRoutes(RouteTable.Routes);

            //Setup DI
            DI.Initialise();

            //GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new NHibernateContractResolver();
        }
    }
}
