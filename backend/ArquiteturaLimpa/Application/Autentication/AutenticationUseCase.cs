using Domain.Entities.User;
using DomainValidationCore.Interfaces.Specification;
using DomainValidationCore.Validation;
using PearlCore.Security;
using Security.Secret.Argon2;
using Service.User;
using Service.User.Interface;

namespace Application.Autentication;

public class AutenticationUseCase : Validator<AutenticationCommand>
{
    public AutenticationUseCase()
    {
        Add("IsCpfNoExist", new Rule<AutenticationCommand>(new IsCpfNoExist(), "Cpf: no exist"));
        Add("IsPasswordInvalid", new Rule<AutenticationCommand>(new IsPasswordInvalid(), "Password: invalid"));
    }

    public class IsCpfNoExist : ISpecification<AutenticationCommand>
    {
        private readonly IUserService userService;

        public IsCpfNoExist()
        {
            this.userService = new UserService();
        }

        public bool IsSatisfiedBy(AutenticationCommand model)
        {
            try
            {
                return userService.FindFirst(new UserEntitie(cpf: model.Cpf)).Result.Data.Id != null;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
    }

    public class IsPasswordInvalid : ISpecification<AutenticationCommand>
    {
        private readonly IUserService userService;

        public IsPasswordInvalid()
        {
            this.userService = new UserService();
        }

        public bool IsSatisfiedBy(AutenticationCommand model)
        {
            try
            {
                var user = userService.FindFirst(new UserEntitie(cpf: model.Cpf)).Result.Data;

                return EncryptArgon2.Verify(SecretArgon2.secret, user.Password, model.Password);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
 
