namespace Query.User
{
    public static class UserCommandQuerySelect
    {
        public static string Command()
        {

            return @"
    				SELECT 
									* 
					FROM 
										dbo.Users
					WHERE 
										(@Id			  IS NULL OR Id				 = @Id				) AND
										(@Cpf             IS NULL OR Cpf             = @Cpf            ) AND
										(@Name            IS NULL OR Name            = @Name           ) AND
										(@Surname         IS NULL OR Surname         = @Surname        ) AND
										(@DisplayName     IS NULL OR DisplayName     = @DisplayName    ) AND
										(@BirthDate       IS NULL OR BirthDate       = @BirthDate      ) AND
										(@Email           IS NULL OR Email           = @Email          ) AND
										(@IdTypeSex       IS NULL OR IdTypeSex       = @IdTypeSex      ) AND
										(@IdTypeRaceColor IS NULL OR IdTypeRaceColor = @IdTypeRaceColor) AND
										(@IdTypeProfile   IS NULL OR IdTypeProfile   = @IdTypeProfile  ) AND
										(@Password        IS NULL OR Password        = @Password       ) AND
										(@ImageProfile    IS NULL OR ImageProfile    = @ImageProfile   ) 
					";
        }
    }
}
