using DrSproc;
using DrSprocExample.DAL.Databases;

namespace DrSprocExample.DAL.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        public ITransaction GetTransaction()
        {
            return DoctorSproc.BeginTransaction<ContosoDb>();
        }
    }
}