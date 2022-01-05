using DALE2ETest.Models;
using DrSproc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DALE2ETest.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployees();

        Task<Employee> GetEmployee(int id);

        Task<int> CreateEmployee(Employee employee, ITransaction transaction = null);
        
        Task UpdateEmployee(Employee employee, ITransaction transaction = null);
    }
}