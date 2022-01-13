using DrSproc;
using DrSprocExample.DAL.CustomMappers;
using DrSprocExample.DAL.Databases;
using DrSprocExample.DAL.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DrSprocExample.DAL.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ISqlConnector connector;

        public EmployeeRepository(ISqlConnector connector)
        {
            this.connector = connector;
        }

        public Task<IEnumerable<Employee>> GetEmployees(CancellationToken cancellationToken = default)
        {
            var db = connector.Use<ContosoDb>();

            return db.ExecuteAsync("sp_GetEmployees")
                            .ReturnMulti<Employee>()
                            .UseCustomMapping<EmployeeCustomMapper>()
                                .GoAsync(cancellationToken);
        }

        public Task<Employee> GetEmployee(int id, CancellationToken cancellationToken = default)
        {
            var db = connector.Use<ContosoDb>();
            
            return db.ExecuteAsync("sp_GetEmployee")
                            .WithParam("EmployeeId", id)
                                .ReturnSingle<Employee>()
                                .UseCustomMapping<EmployeeCustomMapper>()
                                    .GoAsync(cancellationToken);
        }

        public async Task<int> CreateEmployee(Employee mainItem, ITransaction transaction = null, CancellationToken cancellationToken = default)
        {
            var target = connector.UseOptional<ContosoDb>(transaction);

            var id = await target.ExecuteAsync("sp_CreateEmployee")
                                    .WithParam("FirstName", mainItem.FirstName)
                                    .WithParam("LastName", mainItem.LastName)
                                    .WithParamIfNotNull("DateOfBirth", mainItem.DateOfBirth)
                                    .WithParamIfNotNull("DepartmentId", mainItem.Department?.Id)
                                        .ReturnIdentity()
                                            .GoAsync(cancellationToken);

            return Convert.ToInt32(id);
        }

        public Task UpdateEmployee(Employee employee, ITransaction transaction = null, CancellationToken cancellationToken = default)
        {
            var target = connector.UseOptional<ContosoDb>(transaction);

            return target.ExecuteAsync("sp_CreateEmployee")
                                    .WithParam("EmployeeId", employee.Id)
                                    .WithParam("FirstName", employee.FirstName)
                                    .WithParam("LastName", employee.LastName)
                                    .WithParamIfNotNull("DateOfBirth", employee.DateOfBirth)
                                    .WithParamIfNotNull("DepartmentId", employee.Department?.Id)
                                        .GoAsync(cancellationToken);
        }
    }
}
