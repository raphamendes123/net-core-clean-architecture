using Base;
using PearlCore.UnitOfWork;

namespace Repository.Common
{
    public class UnitOfWorkService
    {
        public IUnitOfWork OpenTransaction()
        {
            return new UnitOfWork(new DbSession(ConnectionString.ReturnConnectionString()));
        }

        public IUnitOfWork OpenTransaction(string connectionString)
        {
            return new UnitOfWork(new DbSession(connectionString));
        }
    }
}
