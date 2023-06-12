using API_WebGeo.Models.Login;
using API_WebGeo.Models.Registo;
using System.Web.Http;
using Unity;
using Unity.Lifetime;
using Unity.WebApi;

namespace API_WebGeo
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);

            container.RegisterType<IRegistoRepository, RegistoRepository>(new HierarchicalLifetimeManager());

            container.RegisterType<ILoginRepository, LoginRepository>(new HierarchicalLifetimeManager());
        }
    }
}