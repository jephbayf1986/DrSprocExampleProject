using System;

namespace DALE2ETest.Models
{
    public class MainItem
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

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
                return DateTime.Now.Year - DateOfBirth.Year;
            }
        }
        
        public SubItem SubItem { get; set; }
    }
}