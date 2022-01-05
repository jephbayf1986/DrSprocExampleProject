using DALE2ETest.Repositories;
using DrSproc.Registration;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace UnityE2ETest
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterDrSproc();

            container.RegisterType<IEmployeeRepository, EmployeeRepository>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}