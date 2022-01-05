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

        public Task<IEnumerable<MainItem>> GetEmployees()
        {
            throw new NotImplementedException();
        }

        public Task<MainItem> GetEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> CreateEmployee(MainItem mainItem, ITransaction transaction = null)
        {
            throw new NotImplementedException();
        }

        public Task UpdateEmployee(MainItem mainItem, ITransaction transaction = null)
        {
            throw new NotImplementedException();
        }
    }
}
