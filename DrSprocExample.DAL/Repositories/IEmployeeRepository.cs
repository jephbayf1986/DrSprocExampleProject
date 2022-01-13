using DrSproc;
using DrSprocExample.DAL.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DrSprocExample.DAL.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployees(CancellationToken cancellationToken = default);

        Task<Employee> GetEmployee(int id, CancellationToken cancellationToken = default);

        Task<int> CreateEmployee(Employee employee, ITransaction transaction = null, CancellationToken cancellationToken = default);
        
        Task UpdateEmployee(Employee employee, ITransaction transaction = null, CancellationToken cancellationToken = default);
    }
}