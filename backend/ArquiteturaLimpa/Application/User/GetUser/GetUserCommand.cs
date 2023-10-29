using Domain.Entities.User;
using Infrastructure.Common.Api;
using MediatR;
using PearlCore.ADO.NET;

namespace Application.User.GetUser
{
    public record GetUserCommand : IRequest<Response<List<UserDTO>>>
    {
        public long? Id { get; set; } = null;
        public long? Cpf { get; set; } = null;
        public string? Name { get; set; } = null;
        public string? Surname { get; set; } = null;
        public string? DisplayName { get; set; } = null;
        public DateTime? BirthDate { get; set; } = null;
        public string? Email { get; set; } = null;
        public int? IdTypeSex { get; set; } = null;
        public int? IdTypeRaceColor { get; set; } = null;
        public int? IdTypeProfile { get; set; } = null; 
        public string? ImageProfile { get; set; } = null;

        public GetUserCommand() { }

        public GetUserCommand(long? id = null, long? cpf = null, string? name = null, string? surname = null, string? displayName = null, DateTime? birthDate = null, string? email = null, int? idTypeSex = null, int? idTypeRaceColor = null, int? idTypeProfile = null, string? password = null, string? imageProfile = null)
        {
            Id = id;
            Cpf = cpf;
            Name = name;
            Surname = surname;
            DisplayName = displayName;
            BirthDate = birthDate;
            Email = email;
            IdTypeSex = idTypeSex;
            IdTypeRaceColor = idTypeRaceColor;
            IdTypeProfile = idTypeProfile; 
            ImageProfile = imageProfile;
        }
    }
}