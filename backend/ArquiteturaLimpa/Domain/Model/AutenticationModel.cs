namespace Domain.Model
{
    public class AutenticationModel
    {
        public string? Password { get; set; } = null;
        public long? Cpf { get; set; } = null;
        public AutenticationModel() { }

        public AutenticationModel(long? cpf = null, string? password = null)
        {
            this.Cpf = cpf;
            this.Password = password;
        }
    }
}
