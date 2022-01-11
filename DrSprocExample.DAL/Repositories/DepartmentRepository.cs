using DALE2ETest.Databases;
using DALE2ETest.Models;
using DrSproc;
using System;
using System.Collections.Generic;

namespace DALE2ETest.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ISqlConnector connector;

        public DepartmentRepository(ISqlConnector connector)
        {
            this.connector = connector;
        }

        public IEnumerable<Department> GetDepartments()
        {
            var db = connector.Use<ContosoDb>();

            return db.Execute("sp_GetDepartments")
                            .ReturnMulti<Department>()
                                .Go();
        }

        public int CreateDepartment(Department department, ITransaction transaction = null)
        {
            var target = connector.UseOptional<ContosoDb>(transaction);

            var id = target.Execute("sp_CreateDepartment")
                                    .WithParam("DepartmentName", department.Name)
                                        .ReturnIdentity(allowNull: false)
                                            .Go();



            return Convert.ToInt32(id);
        }

        public void UpdateSubItem(Department department, ITransaction transaction = null)
        {
            var target = connector.UseOptional<ContosoDb>(transaction);

            target.Execute("sp_UpdateDepartment")
                        .WithParam("@DepartmentId", department.Id)
                        .WithParam("@DepartmentName", department.Name)
                            .Go();
        }
    }
}
