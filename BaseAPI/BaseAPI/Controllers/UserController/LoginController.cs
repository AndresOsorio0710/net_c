using BaseAPI.Business.Interface.Authentication;
using BaseAPI.Business.Interface.Security;
using BaseAPI.Entities.Responces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BaseAPI.Controllers.UserController
{
    public class LoginController : ApiController
    {
        private readonly ICryptographyBusiness cryptographyBusiness;
        private readonly ILoginBusiness loginBusiness;
        public LoginController(ICryptographyBusiness cryptographyBusiness, ILoginBusiness loginBusiness)
        {
            this.cryptographyBusiness = cryptographyBusiness;
            this.loginBusiness = loginBusiness;
        }

        [HttpPost]
        [Route("Login")]
        [Produces("application/json", Type = typeof(TransactionResponse<LoginResponce>))]
        public IActionResult Login([FromBody] string request) {
            TransactionResponse<LoginResponce> response = this.loginBusiness.Login(request);
            this.resultString = JsonConvert.SerializeObject(response);
            this.resultString = this.cryptographyBusiness.Encrypting(this.resultString);
            return StatusCode((int)response.ResultTransaction.Code, resultString);
        }
    }
}
