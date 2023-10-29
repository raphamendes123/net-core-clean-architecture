using Application.Autentication;
using Domain.Model.Autentication;
using Infrastructure.Common.Api;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.User
{
    public class AutenticationController : ApiControllerBase
    {
        public AutenticationController() {}        

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<AutenticationResponse> Create([FromBody] AutenticationCommand command)
        {
            return await Mediator.Send(command);
        }         
    }
}