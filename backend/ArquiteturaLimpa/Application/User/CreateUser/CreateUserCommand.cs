using Infrastructure.Common.Api;
using MediatR; 

namespace Application.User.CreateUser
{
    public record CreateUserCommand : IRequest<Response<long>>
    {
        public long? Cpf { get; set; } = null;
        public string? Name { get; set; } = null;
        public string? Surname { get; set; } = null;
        public string? DisplayName { get; set; } = null;
        public DateTime? BirthDate { get; set; } = null;
        public string? Email { get; set; } = null;
        public int? IdTypeSex { get; set; } = null;
        public int? IdTypeRaceColor { get; set; } = null; 
        public string? Password { get; set; } = null;
        public string? ImageProfile { get; set; } = null;

        public CreateUserCommand() { }

        public CreateUserCommand(long? cpf = null, string? name = null, string? surname = null, string? displayName = null, DateTime? birthDate = null, string? email = null, int? idTypeSex = null, int? idTypeRaceColor = null, string? password = null, string? imageProfile = null)
        {
            Cpf = cpf;
            Name = name;
            Surname = surname;
            DisplayName = displayName;
            BirthDate = birthDate;
            Email = email;
            IdTypeSex = idTypeSex;
            IdTypeRaceColor = idTypeRaceColor; 
            Password = password;
            ImageProfile = imageProfile;
        }
    }
}