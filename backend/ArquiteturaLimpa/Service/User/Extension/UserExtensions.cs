using Domain.Entities.User;
using Domain.Enumerator;
using PearlCore.Security;
using Security.Secret.Argon2;

namespace Service.User.Extension
{
    public static class UserExtensions
    {
        public static UserEntitie UserModify(this UserEntitie entitieOriginal, UserEntitie entitieModified)
        {
            entitieOriginal.Name = entitieModified.Name;
            entitieOriginal.Surname = entitieModified.Surname;
            entitieOriginal.DisplayName = entitieModified.DisplayName;
            entitieOriginal.BirthDate = entitieModified.BirthDate;
            entitieOriginal.IdTypeRaceColor = entitieModified.IdTypeRaceColor;
            entitieOriginal.IdTypeSex = entitieModified.IdTypeSex;

            return entitieOriginal;
        }

        public static UserEntitie UserCreate(this UserEntitie entitie)
        {
            entitie.IdTypeProfile = (int)EnumTypeProfile.UserStandard;
            entitie.Password = EncryptArgon2.Encrypt(SecretArgon2.secret, entitie.Password);

            return entitie;
        }

    }
}
