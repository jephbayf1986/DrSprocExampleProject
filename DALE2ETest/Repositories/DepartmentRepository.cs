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

        public int CreateSubItem(Department department, ITransaction transaction = null)
        {
            var target = GetTargetConnection(transaction);

            var id = target.Execute("sp_CreateDepartment")
                                    .WithParam("DepartmentName", department.Name)
                                        .ReturnIdentity(allowNull: false)
                                            .Go();

            return Convert.ToInt32(id);
        }

        public void UpdateSubItem(Department department, ITransaction transaction = null)
        {
            var target = GetTargetConnection(transaction);

            target.Execute("sp_UpdateDepartment")
                        .WithParam("@DepartmentId", department.Id)
                        .WithParam("@DepartmentName", department.Name)
                            .Go();
        }

        private ITargetConnection GetTargetConnection(ITransaction transaction = null)
        {
            if (transaction != null && transaction is ITransaction<ContosoDb>)
                return connector.Use(transaction as ITransaction<ContosoDb>);
            else
                return connector.Use<ContosoDb>();
        }
    }
}
