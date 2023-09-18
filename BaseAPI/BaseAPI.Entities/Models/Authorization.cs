namespace BaseAPI.Entities.Models
{
	public class Authorization
    {
        public string SecretKey { get; set; }
        public string MethodEncrypt { get; set; }
        public int TokenExpirationMinutes { get; set; }
        public string Issuer  { get; set; }
        public string Audience { get; set; }
        public Authorization()
		{
		}
	}
}

