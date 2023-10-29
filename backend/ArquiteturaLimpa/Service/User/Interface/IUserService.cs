using Domain.Entities.User;
using PearlCore.ADO.NET;
using PearlCore.UnitOfWork;

namespace Service.User.Interface
{
    public interface IUserService
    {
        public IUnitOfWork? unitOfWork { get; }
        Task<ExecutionResult<long>> Create(UserEntitie userDTO);
        Task<ExecutionResult<bool>> Update(UserEntitie userDTO);
        Task<ExecutionResult<bool>> Delete(long id);
        Task<ExecutionResult<List<UserEntitie>>> FindAll(UserEntitie userDTO);
        Task<ExecutionResult<UserEntitie>> FindFirst(UserEntitie userDTO);
    }
}
