using Domain.Entities.User;
using PearlCore.ADO.NET;

namespace Repository.User
{
    public interface IUserRepository
    {
        public Task<ExecutionResult<long>> Save(UserEntitie entitie);
        public Task<ExecutionResult<bool>> Update(UserEntitie entitie);
        public Task<ExecutionResult<bool>> Delete(long id);
        public Task<ExecutionResult<List<UserEntitie>>> FindAll(UserEntitie entitie);
        public Task<ExecutionResult<UserEntitie>> FindFirst(UserEntitie entitie);
    }
}
