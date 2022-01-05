using DALE2ETest.Models;
using DrSproc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DALE2ETest.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<MainItem>> GetEmployees();

        Task<MainItem> GetEmployee(int id);

        Task<int> CreateEmployee(MainItem mainItem, ITransaction transaction = null);

        Task UpdateEmployee(MainItem mainItem, ITransaction transaction = null);
    }
}