using AmigosRESTAPI.Models;
using AmigosRESTAPI.Models.Atividades;
using AmigosRESTAPI.Models.Notificacoes;
using AmigosRESTAPI.Models.Utilizador;
using AmigosRESTAPI.Models.Vizinhanca;
using System.Web.Http;
using Unity;
using Unity.Lifetime;
using Unity.WebApi;

namespace AmigosRESTAPI
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
            container.RegisterType<IAmigoRepository, AmigoRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IUtilizadorRepository, UtilizadorRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IVizinhancaGeoRepository, VizinhancaGeoRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IAtividadesRepository, AtividadesRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<INotificacoesRepository, NotificacoesRepository>(new HierarchicalLifetimeManager());
        }
    }
}