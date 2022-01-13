using DrSproc.Registration;
using DrSprocExample.DAL.Repositories;
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
            container.RegisterType<IDepartmentRepository, DepartmentRepository>();
            container.RegisterType<ITransactionRepository, TransactionRepository>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}