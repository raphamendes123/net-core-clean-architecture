namespace Domain.Model.Autentication
{
    public class AutenticationResponse
    {
        public string? access_token { get; set; } = null;
        public string? token_type { get; set; } = null;
        public DateTime? expires_in { get; set; } = null;

        public AutenticationResponse(){}

        public AutenticationResponse(string? access_token = null, string? token_type = null, DateTime? expires_in = null)
        {
            this.access_token = access_token;
            this.token_type = token_type;
            this.expires_in = expires_in;
        }
    }
}
