using Application.Common.Pagination;
using Domain.Entities.User;
using MediatR;

namespace Application.User.GetPaginationUser
{
    public record GetUserPaginationCommand : IRequest<PaginatedList<UserDTO>>
    {
        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } = 25;

        public long? Id { get; set; } = null;
        public long? Cpf { get; set; } = null;
        public string? Name { get; set; } = null;
        public string? Surname { get; set; } = null;
        public string? DisplayName { get; set; } = null;
        public DateTime? BirthDate { get; set; } = null;
        public string? Email { get; set; } = null;
        public long? IdTypeSex { get; set; } = null;
        public long? IdTypeRaceColor { get; set; } = null;
        public long? IdTypeProfile { get; set; } = null; 
        public string? ImageProfile { get; set; } = null;

        public GetUserPaginationCommand() { }

        public GetUserPaginationCommand(long? id = null, long? cpf = null, string? name = null, string? surname = null, string? displayName = null, DateTime? birthDate = null, string? email = null, long? idTypeSex = null, long? idTypeRaceColor = null, long? idTypeProfile = null, string? imageProfile = null)
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