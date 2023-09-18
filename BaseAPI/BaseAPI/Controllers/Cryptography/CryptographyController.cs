using BaseAPI.Business.Interface.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BaseAPI.Controllers.Cryptography
{
    public class CryptographyController:ApiController
    {
        private readonly ICryptographyBusiness cryptographyBusiness;
        public CryptographyController(ICryptographyBusiness cryptographyBusiness)
        {
            this.cryptographyBusiness = cryptographyBusiness;
        }

        [Authorize]
        [HttpGet]
        [Route("Encrypting")]
        public IActionResult Encrypting(string request)
        {
            this.resultString = this.cryptographyBusiness.Encrypting(request);
            return StatusCode(200, this.resultString);
        }

        [HttpGet]
        [Route("Decrypting")]
        public IActionResult Decrypting(string request)
        {
            this.resultString = this.cryptographyBusiness.Decrypting(request);
            return StatusCode(200, this.resultString);
        }
    }
}
