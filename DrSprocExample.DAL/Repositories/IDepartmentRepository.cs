using DALE2ETest.Models;
using DrSproc;
using System.Collections.Generic;

namespace DALE2ETest.Repositories
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetDepartments();

        int CreateDepartment(Department department, ITransaction transaction = null);
        
        void UpdateSubItem(Department department, ITransaction transaction = null);
    }
}
