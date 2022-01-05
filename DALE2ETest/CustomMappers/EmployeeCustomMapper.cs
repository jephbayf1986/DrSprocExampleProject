using DALE2ETest.Models;
using DrSproc.EntityMapping;

namespace DALE2ETest.CustomMappers
{
    internal class EmployeeCustomMapper : CustomMapper<Employee>
    {
        public override Employee Map()
        {
            Department department = null;

            var departmentId = ReadNullableInt("DepartmentId");

            if (departmentId != null)
            {
                department = new Department()
                {
                    Id = departmentId.Value,
                    Name = ReadString("DepartmentName")
                };
            }

            return new Employee()
            {
                Id = ReadInt("Id"),
                FirstName = ReadString(""),
                LastName = ReadString(""),
                DateOfBirth = ReadDateTime(""),
                Department = department
            };
        }
    }
}
