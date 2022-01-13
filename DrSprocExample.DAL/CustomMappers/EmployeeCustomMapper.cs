using DrSproc.EntityMapping;
using DrSprocExample.DAL.Models;

namespace DrSprocExample.DAL.CustomMappers
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
                FirstName = ReadString("FirstName"),
                LastName = ReadString("LastName"),
                DateOfBirth = ReadDateTime("DateOfBirth"),
                Department = department
            };
        }
    }
}
