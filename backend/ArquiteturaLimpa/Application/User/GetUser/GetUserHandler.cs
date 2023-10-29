using AutoMapper;
using Domain.Entities.User;
using Infrastructure.Common.Api;
using MediatR;
using PearlCore.ADO.NET;
using Service.User.Interface;

namespace Application.User.GetUser;

public class GetUserHandler : IRequestHandler<GetUserCommand, Response<List<UserDTO>>>
{
    private readonly IMapper mapper;
    private readonly IUserService userService;

    public GetUserHandler(IUserService userService, IMapper mapper)
    {
        this.userService = userService;
        this.mapper = mapper;
    }

    public async Task<Response<List<UserDTO>>> Handle(GetUserCommand request, CancellationToken cancellationToken)
    {
        var executionResult = new ExecutionResult<List<UserDTO>>();

        var user = mapper.Map<UserEntitie>(request);

        var listUser = await userService.FindAll(user);

        executionResult.Data = mapper.Map<List<UserDTO>>(listUser.Data);

        return new Response<List<UserDTO>> { Data = executionResult.Data};
    }
}
