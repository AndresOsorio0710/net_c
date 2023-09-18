using BaseAPI.Business.Interface.Security;
using Microsoft.AspNetCore.Mvc;

namespace BaseAPI.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        public string resultString = string.Empty;

    }
}
