namespace Query.User
{
    public static class UserCommandQueryUpdate
    {
        public static string Command()
        {
            return @"

					  UPDATE 
  								dbo.Users
					  SET 	  
	  							Cpf             = Cpf              ,
								Name            = @Name             ,
								Surname         = @Surname          ,
								DisplayName     = @DisplayName      ,
								BirthDate       = @BirthDate        ,
								Email           = @Email            ,
								IdTypeSex       = @IdTypeSex        ,
								IdTypeRaceColor = @IdTypeRaceColor  ,
								IdTypeProfile   = IdTypeProfile    ,
								Password        = Password         ,
								ImageProfile    = @ImageProfile    
					  WHERE
          						Id = @Id  
                    ";
        } 
    }
}
