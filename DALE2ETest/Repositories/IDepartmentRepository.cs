using DALE2ETest.Models;
using DrSproc;
using System.Threading.Tasks;

namespace DALE2ETest.Repositories
{
    public interface IDepartmentRepository
    {
        Task<int> CreateSubItem(Department subItem, ITransaction transaction = null);

        Task UpdateSubItem(Department subItem, ITransaction transaction = null);
    }
}
