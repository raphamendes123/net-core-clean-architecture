using Infrastructure.Common.Api;
using MediatR;

namespace Application.User.DeleteUser
{
    public record DeleteUserCommand : IRequest<Response<bool>>
    {
        public long? Id { get; set; } = null; 

        public DeleteUserCommand()
        {
        }

        public DeleteUserCommand(long? id = null)
        {
            Id = id;
        }
    }
}