using Application.Autentication;
using Application.Common.Pagination;
using Application.User.CreateUser;
using Application.User.DeleteUser;
using Application.User.GetPaginationUser;
using Application.User.GetUser;
using Application.User.UpdateUser;
using Domain.Entities.User;
using Domain.Model.Autentication;
using Infrastructure.Common.Api;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PearlCore.ADO.NET;
using Service.Autentication;
using Service.Autentication.Interface;
using Service.User;
using Service.User.Interface;

namespace Infrastructure.DependencyInjection
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        { 
            services.AddSingleton<IUserService, UserService>();
            services.AddTransient<IRequestHandler<CreateUserCommand, Response<long>>, CreateUserHandler>();
            services.AddTransient<IRequestHandler<UpdateUserCommand, Response<bool>>, UpdateUserHandler>();
            services.AddTransient<IRequestHandler<DeleteUserCommand, Response<bool>>, DeleteUserHandler>();
            services.AddTransient<IRequestHandler<GetUserCommand, Response<List<UserDTO>>>, GetUserHandler>();
            services.AddTransient<IRequestHandler<GetUserPaginationCommand, PaginatedList<UserDTO>>, GetUserPaginationHandler>();

            services.AddSingleton<IAutenticationService, AutenticationService>();
            services.AddTransient<IRequestHandler<AutenticationCommand, AutenticationResponse>, AutenticationHandler>();


            return services;
        }

    }
}
