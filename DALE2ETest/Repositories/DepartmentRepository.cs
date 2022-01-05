﻿using DALE2ETest.Models;
using DrSproc;
using System;
using System.Threading.Tasks;

namespace DALE2ETest.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ISqlConnector connector;

        public DepartmentRepository(ISqlConnector connector)
        {
            this.connector = connector;
        }

        public Task<int> CreateSubItem(Department subItem, ITransaction transaction = null)
        {
            throw new NotImplementedException();
        }

        public Task UpdateSubItem(Department subItem, ITransaction transaction = null)
        {
            throw new NotImplementedException();
        }
    }
}
