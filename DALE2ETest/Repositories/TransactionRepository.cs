using DALE2ETest.Databases;
using DrSproc;

namespace DALE2ETest.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        public ITransaction GetTransaction()
        {
            return DoctorSproc.BeginTransaction<ContosoDb>();
        }
    }
}