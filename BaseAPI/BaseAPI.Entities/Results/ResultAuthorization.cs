namespace BaseAPI.Entities.Results
{
    public class ResultAuthorization
    {
        public string AccessToken { get; set; }
        public DateTime? ExpiresIn { get; set; }
        public string TokenType { get; set; }
    }
}
