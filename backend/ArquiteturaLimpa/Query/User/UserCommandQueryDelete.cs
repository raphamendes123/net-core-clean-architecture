namespace Query.User
{
    public static class UserCommandQueryDelete
    {
        public static string Command()
        {
            return @"DELETE FROM dbo.Users WHERE Id = @Id";
        }  
    }
}
