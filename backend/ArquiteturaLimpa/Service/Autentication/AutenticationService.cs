using Domain.Entities.User;
using Domain.Enumerator;
using Domain.Model;
using Domain.Model.Autentication;
using PearlCore.ADO.NET;
using PearlCore.Security;
using Security.Secret.Jwt;
using Service.Autentication.Interface;
using Service.User.Interface; 

namespace Service.Autentication
{
    public class AutenticationService : IAutenticationService
    {
        public readonly IUserService userService;

        public AutenticationService(IUserService userService)
        {
            this.userService = userService;
        }

        public Task<AutenticationResponse> Authenticate(AutenticationModel autenticationModel)
        {
            var user = userService.FindFirst(new UserEntitie(cpf: autenticationModel.Cpf)).Result.Data;

            var idTypeProfile = (EnumTypeProfile)user.IdTypeProfile;

            var result = JwtGenerator.GenerateToken(secretJwt: SecretJwt.Secret, nameIdentifier: user.Id.ToString(), name: user.Cpf.ToString(), email: user.Email, role: idTypeProfile.ToString(), minuteExpiration: 30);

            return Task.FromResult(new AutenticationResponse() { access_token = result.access_token, expires_in = result.expires_in, token_type = result.token_type });
        }
    }
}
