using DrSproc;
using System.Configuration;

namespace DALE2ETest.Databases
{
    public class ContosoDb : IDatabase
    {
        public string GetConnectionString()
        {
            var connection =  ConfigurationManager.ConnectionStrings["DrSprocTest"].ConnectionString;

            return connection;
        }
    }
}
