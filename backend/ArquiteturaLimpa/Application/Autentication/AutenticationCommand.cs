using Domain.Model.Autentication;
using Infrastructure.Common.Api;
using MediatR; 

namespace Application.Autentication
{
    public record AutenticationCommand : IRequest<AutenticationResponse>
    {
        public long? Cpf { get; set; } = null;
        public string? Password { get; set; } = null;

        public AutenticationCommand(){}

        public AutenticationCommand(long? cpf = null, string? password = null)
        {
            Cpf = cpf;
            Password = password;
        }
    }
}