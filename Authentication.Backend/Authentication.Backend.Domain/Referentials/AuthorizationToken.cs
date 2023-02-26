namespace Authentication.Backend.Domain.Referentials
{
    public class AuthorizationToken
    {
        /// <summary>
        /// Get or Set, id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Get or Set, token type
        /// </summary>
        /// <valus>
        /// TokenType, string
        /// </valus>
        public string TokenType { get; set; }

        /// <summary>
        /// Get or Set, access token
        /// </summary>
        /// <valus>
        /// AccessToken, string
        /// </valus>
        public string AccessToken { get; set; }

        /// <summary>
        /// Get or Set, sxpire
        /// </summary>
        /// <valus>
        /// Expire, DateTime
        /// </valus>
        public DateTime? Expire { get; set; }
    }
}
