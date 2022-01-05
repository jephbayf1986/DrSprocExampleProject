using DALE2ETest.Models;
using DrSproc;
using System.Threading.Tasks;

namespace DALE2ETest.Repositories
{
    public interface IDepartmentRepository
    {
        Task<int> CreateSubItem(SubItem subItem, ITransaction transaction = null);

        Task UpdateSubItem(SubItem subItem, ITransaction transaction = null);
    }
}
