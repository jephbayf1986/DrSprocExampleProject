using DrSproc;
using DrSprocExample.DAL.Models;
using System.Collections.Generic;

namespace DrSprocExample.DAL.Repositories
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetDepartments();

        int CreateDepartment(Department department, ITransaction transaction = null);
        
        void UpdateDepartment(Department department, ITransaction transaction = null);
    }
}
