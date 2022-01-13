using DrSproc;
using System.Configuration;

namespace DrSprocExample.DAL.Databases
{
    public class ContosoDb : IDatabase
    {
        public string GetConnectionString()
        {
            var connection = ConfigurationManager.ConnectionStrings["DrSprocTest"].ConnectionString;

            return connection;
        }
    }
}
