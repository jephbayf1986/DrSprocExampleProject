using System;

namespace DALE2ETest.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string FullName 
        { 
            get
            {
                return FirstName + " " + LastName; 
            }
        }

        public int Age
        {
            get
            {
                if (DateOfBirth == null) return 0;

                return DateTime.Now.Year - DateOfBirth.Value.Year;
            }
        }
        
        public Department Department { get; set; }
    }
}