using AutoMapper;
using Domain.Entities.User;
using Infrastructure.Common.Api;
using MediatR;
using Repository.Common;
using Service.User;
using Service.User.Interface;

namespace Application.User.UpdateUser;

public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, Response<bool>>
{
    private readonly IMapper mapper;
    private readonly IUserService userService;

    public UpdateUserHandler(IUserService userService, IMapper mapper)
    {
        this.userService = new UserService(new UnitOfWorkService().OpenTransaction());
        this.mapper = mapper;
    }

    public async Task<Response<bool>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = mapper.Map<UserEntitie>(request);

        this.userService.unitOfWork?.BeginTransaction();

        var result = await userService.Update(user);

        this.userService.unitOfWork?.Complete();

        return new Response<bool> { Data = result.Data };
    }

}
