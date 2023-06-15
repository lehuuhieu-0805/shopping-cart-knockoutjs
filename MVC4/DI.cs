using System.Web.Mvc;
using Microsoft.Practices.Unity;
using MVC4.SERVICE.Infrastructures;
using MVC4.SERVICE.Services;
using Unity.Mvc4;

namespace MVC4
{
    public static class DI
    {
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            return container;
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();    
            container.RegisterType<ICustomerService, CustomerService>();
            container.RegisterType<ILambdaService, LambdaService>();
            container.RegisterType<IProductService, ProductService>();
            container.RegisterType<ICategoryService, CategoryService>();
            container.RegisterType<ICartService, CartService>();
            container.RegisterType<ICartItemService, CartItemService>();
            RegisterTypes(container);

            return container;
        }

        public static void RegisterTypes(IUnityContainer container)
        {

        }
    }
}