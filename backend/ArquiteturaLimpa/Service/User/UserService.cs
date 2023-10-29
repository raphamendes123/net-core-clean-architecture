using Repository;
using Domain.Entities.User;
using PearlCore.UnitOfWork;
using PearlCore.ADO.NET;
using Repository.User;
using Service.User.Extension;
using Service.User.Interface;

namespace Service.User
{
    public class UserService : IUserService
    { 
        public readonly IUserRepository repository;

        public IUnitOfWork? unitOfWork { get; }

        public UserService(IUnitOfWork? unitOfWork = null)
        { 
            this.unitOfWork = unitOfWork;
            this.repository = new UserRepository(unitOfWork);
        }
         
        public async Task<ExecutionResult<long>> Create(UserEntitie entitie)
        {
            entitie.UserCreate();

            return await repository.Save(entitie);
        }

        public async Task<ExecutionResult<bool>> Update(UserEntitie entitie)
        {
            var user = FindFirst(new UserEntitie(id: entitie.Id)).Result.Data;

            user.UserModify(entitie);

            return await repository.Update(user);
        }

        public async Task<ExecutionResult<bool>> Delete(long id)
        {
            return await repository.Delete(id);
        }

        public async Task<ExecutionResult<List<UserEntitie>>> FindAll(UserEntitie entitie)
        {   
            return await repository.FindAll(entitie);
        }

        public async Task<ExecutionResult<UserEntitie>> FindFirst(UserEntitie entitie)
        {
            return await repository.FindFirst(entitie);
        }
    }
}
