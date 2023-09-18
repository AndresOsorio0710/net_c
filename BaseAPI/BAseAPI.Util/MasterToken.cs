using System.Globalization;
using BaseAPI.Entities.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BaseAPI.Util
{
	public class MasterToken : MasterBase
	{

		private Authorization authorization;

        public MasterToken()
		{
            this.authorization = new Authorization {
                SecretKey = this.configuration["Authorization:SecretKey"],
                MethodEncrypt = this.configuration["Authorization:MethodEncrypt"],
                TokenExpirationMinutes = int.Parse(this.configuration["Authorization:TokenExpirationMinutes"]
                .ToString(CultureInfo.InvariantCulture)),
                Issuer = this.configuration["Authorization:Issuer"],
                Audience = this.configuration["Authorization:Audience"],
            };
		}

		public string GenerateJwtToken(string userId)
		{
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(this.authorization.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, userId),
                // Puedes agregar otras reclamaciones personalizadas aquí
            }),
                Expires = DateTime.UtcNow.AddMinutes(this.authorization.TokenExpirationMinutes),
                SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature
            ),
                Issuer = this.authorization.Issuer,
                Audience = this.authorization.Audience
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string GetUserIdFromToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(this.authorization.SecretKey);

            // Configurar la validación del token
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false, // Puedes configurar esto según tus necesidades
                ValidateAudience = false, // Puedes configurar esto según tus necesidades
                                          // Más configuraciones si es necesario
            };

            SecurityToken securityToken;
            var claimsPrincipal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);

            // Obtener el UserID de las reclamaciones
            var userIdClaim = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim != null)
            {
                return userIdClaim.Value;
            }

            // Si no se encuentra el UserID en las reclamaciones, puedes devolver null o lanzar una excepción según tus necesidades.
            return null;
        }
    }
}

