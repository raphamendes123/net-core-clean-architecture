namespace Query.User
{
    public static class UserCommandQuerySave
    {
        public static string Command()
        {
            return @"
                   
                INSERT INTO dbo.Users
		                (Cpf,Name,Surname,DisplayName,BirthDate,Email,IdTypeSex,IdTypeRaceColor,IdTypeProfile,Password,ImageProfile)   
                VALUES	
		                (@Cpf,@Name,@Surname,@DisplayName,@BirthDate,@Email,@IdTypeSex,@IdTypeRaceColor,@IdTypeProfile,@Password,@ImageProfile)

                SET @Id = @@IDENTITY
            ";
        } 
    }
}
