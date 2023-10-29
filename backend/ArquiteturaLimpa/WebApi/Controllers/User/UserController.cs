using Application.Common.Pagination;
using Application.User.CreateUser;
using Application.User.DeleteUser;
using Application.User.GetPaginationUser;
using Application.User.GetUser;
using Application.User.UpdateUser;
using Domain.Entities.User;
using Infrastructure.Common.Api;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PearlCore.ADO.NET;

namespace WebApi.Controllers.User
{

    //[Authorize]
    public class UserController : ApiControllerBase
    {
        public UserController() {}
        

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Response<long>>> Create([FromBody]CreateUserCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Response<bool>>> Update(int id, UpdateUserCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("Id: fornecido diferente");
            }

            return await Mediator.Send(command); 
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Response<bool>>> Delete(int id)
        {
            return await Mediator.Send(new DeleteUserCommand(id));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Response<List<UserDTO>>>> FindAll([FromQuery] GetUserCommand command)  
        {
            return await Mediator.Send(command);
        }

        [HttpGet("Pagination")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<PaginatedList<UserDTO>>> FindAllPagination([FromQuery] GetUserPaginationCommand command)
        {
            return await Mediator.Send(command);
        }

    }
}