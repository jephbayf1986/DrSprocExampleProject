using DALE2ETest.Databases;
using DALE2ETest.Models;
using DrSproc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DALE2ETest.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ISqlConnector connector;

        public EmployeeRepository(ISqlConnector connector)
        {
            this.connector = connector;
        }

        public Task<IEnumerable<Employee>> GetEmployees()
        {
            var db = connector.Use<ContosoDb>();

            // Example With Mapper

            return db.ExecuteAsync("sp_GetEmployees")
                            .ReturnMulti<Employee>()
                            .Go();
        }

        public Task<Employee> GetEmployee(int id)
        {
            var db = connector.Use<ContosoDb>();
            
            // Example Without Mapper

            return db.ExecuteAsync("sp_GetEmployee")
                            .WithParam("EmployeeId", id)
                            .ReturnSingle<Employee>()
                            .Go();
        }

        public async Task<int> CreateEmployee(Employee mainItem, ITransaction transaction = null)
        {
            ITargetConnection target;

            if (transaction != null && transaction is ITransaction<ContosoDb>)
                target = connector.Use(transaction as ITransaction<ContosoDb>);
            else
                target = connector.Use<ContosoDb>();

            var id = await target.ExecuteAsync("sp_CreateEmployee")
                                    .WithParam("FirstName", mainItem.FirstName)
                                    .WithParam("LastName", mainItem.LastName)
                                    .WithParamIfNotNull("DateOfBirth", mainItem.DateOfBirth)
                                    .WithParamIfNotNull("DepartmentId", mainItem.Department?.Id)
                                    .ReturnIdentity()
                                    .Go();

            return Convert.ToInt32(id);
        }

        public Task UpdateEmployee(Employee employee, ITransaction transaction = null)
        {
            ITargetConnection target;

            if (transaction != null && transaction is ITransaction<ContosoDb>)
                target = connector.Use(transaction as ITransaction<ContosoDb>);
            else
                target = connector.Use<ContosoDb>();

            return target.ExecuteAsync("sp_CreateEmployee")
                                    .WithParam("EmployeeId", employee.Id)
                                    .WithParam("FirstName", employee.FirstName)
                                    .WithParam("LastName", employee.LastName)
                                    .WithParamIfNotNull("DateOfBirth", employee.DateOfBirth)
                                    .WithParamIfNotNull("DepartmentId", employee.Department?.Id)
                                    .Go();
        }
    }
}
