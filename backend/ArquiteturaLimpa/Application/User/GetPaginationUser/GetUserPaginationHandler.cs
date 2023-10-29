using Application.Common;
using Application.Common.Pagination;
using AutoMapper;
using Domain.Entities.User;
using MediatR;
using Service.User.Interface;

namespace Application.User.GetPaginationUser;

public class GetUserPaginationHandler : IRequestHandler<GetUserPaginationCommand, PaginatedList<UserDTO>>
{
    private readonly IMapper mapper;
    private readonly IUserService userService;

    public GetUserPaginationHandler(IUserService userService, IMapper mapper)
    {
        this.userService = userService;
        this.mapper = mapper;
    }

    public async Task<PaginatedList<UserDTO>> Handle(GetUserPaginationCommand request, CancellationToken cancellationToken)
    {
        var user = mapper.Map<UserEntitie>(request);

        var listUser = await userService.FindAll(user);

        var result = mapper.Map<List<UserDTO>>(listUser.Data);

        return await result.PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
