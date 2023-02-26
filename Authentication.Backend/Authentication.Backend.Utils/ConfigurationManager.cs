using Microsoft.Extensions.Configuration;
using System.Globalization;

namespace Authentication.Backend.Utils
{
    public class ConfigurationManager
    {
        private readonly IConfiguration configuration;
        public int JwtMinutesExpirationTime { get; set; }

        /// <summary>
        /// Jwt Default User Name.
        /// </summary>
        public string JwtDefaultUserName { get; set; }

        /// <summary>
        /// Jwt Default User Password.
        /// </summary>
        public string JwtDefaultUserPassword { get; set; }

        /// <summary>
        /// Jwt Encryption Method.
        /// </summary>
        public string JwtEncryptionMethod { get; set; }

        /// <summary>
        /// Jwt Secret Key.
        /// </summary>
        public string JwtSecretKey { get; set; }

        /// <summary>
        /// Application Path.
        /// </summary>
        public static string ApplicationPath { get; set; }

        public ConfigurationManager()
        {
            DiscoverApplicationPath();
            configuration = new ConfigurationBuilder()
                  .SetBasePath(ApplicationPath)
                  .AddJsonFile("appsettings.json", false, true)
                  .AddEnvironmentVariables().Build();
            SetJwtValues();
        }

        public void SetJwtValues()
        {
            JwtMinutesExpirationTime = int.Parse(configuration["AuthorizationJwt:jwtMinutesExpirationTime"]
                .ToString(CultureInfo.InvariantCulture));
            JwtDefaultUserName = configuration["AuthorizationJwt:LoginDefaultUser"];
            JwtDefaultUserPassword = configuration["AuthorizationJwt:LoginDefaultPassword"];
            JwtEncryptionMethod = configuration["AuthorizationJwt:ApplicationMethodEncrypt"];
            JwtSecretKey = configuration["AuthorizationJwt:ApplicationKey"];
        }

        public static void DiscoverApplicationPath()
        {
            ApplicationPath = Path.GetDirectoryName(
                Directory.GetFiles(Directory.GetCurrentDirectory().
                Replace(".Tests\\bin\\Debug\\net6.0", ""),
                "appsettings.json",
                SearchOption.AllDirectories
                ).FirstOrDefault());
        }
    }
}
