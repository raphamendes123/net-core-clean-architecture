using Domain.Model;
using Domain.Model.Autentication;

namespace Service.Autentication.Interface
{
    public interface IAutenticationService
    {
        public Task<AutenticationResponse> Authenticate(AutenticationModel autenticationModel);
    }
}
