using Application.User.CreateUser;
using Application.User.DeleteUser;
using Application.User.GetPaginationUser;
using Application.User.GetUser;
using Application.User.UpdateUser;
using AutoMapper;
using Domain.Entities.User;

namespace Infrastructure.AutoMapper.User
{
    public class UserMappings : Profile
    {
        public UserMappings()
        {
            CreateMap<CreateUserCommand, UserEntitie>();
            CreateMap<UserEntitie, CreateUserCommand>();

            CreateMap<UpdateUserCommand, UserEntitie>();
            CreateMap<UserEntitie, UpdateUserCommand>();

            CreateMap<DeleteUserCommand, UserEntitie>();
            CreateMap<UserEntitie, DeleteUserCommand>();

            CreateMap<GetUserCommand, UserEntitie>();
            CreateMap<UserEntitie, GetUserCommand>();

            CreateMap<GetUserPaginationCommand, UserEntitie>();
            CreateMap<UserEntitie, GetUserPaginationCommand>();

            CreateMap<UserDTO, UserEntitie>();
            CreateMap<UserEntitie, UserDTO>();
        }
    }
}
