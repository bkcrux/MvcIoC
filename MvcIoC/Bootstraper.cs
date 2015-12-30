using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Mvc;
using MvcIoC.Models;

namespace MvcIoC
{
    public static class Bootstraper
    {
        public static IUnityContainer Intialize()
        {
            var container = BuildUnityContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            return container;
 
       }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            //register all components with container here

            //e.g. container.RegisteryType<ITestService, TestService>();
            RegisterTypes(container);

            return container;
        }


        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterTypes(
                AllClasses.FromLoadedAssemblies(),
                WithMappings.FromMatchingInterface,
                WithName.Default);

            container.RegisterType<IProteinRepository, ProteinRepository>(new InjectionConstructor("new data source"));

            //container.RegisterType<IProteinTrackerService, ProteinTrackerService>();
            //container.RegisterType<IProteinRepository, ProteinRepository>();

        }
    }
}