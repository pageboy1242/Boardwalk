using System.Web.Mvc;
using Microsoft.Practices.Unity;
using StampedeMotor.Repositories;
using Unity.Mvc5;

namespace StampedeMotor
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            container.RegisterType<ICarRepository, CarRepository>();
            container.RegisterType<IMakeRepository, MakeRepository>();
            container.RegisterType<IModelRepository, ModelRepository>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}