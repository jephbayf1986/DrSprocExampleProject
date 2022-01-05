using DrSproc;
using System.Configuration;

namespace DALE2ETest.Databases
{
    public class ContosoDb : IDatabase
    {
        public string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings[0].ToString();
        }
    }
}
