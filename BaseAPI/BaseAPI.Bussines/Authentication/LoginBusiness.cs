using BaseAPI.Business.Interface.Authentication;
using BaseAPI.Entities.Enums;
using BaseAPI.Entities.Requests;
using BaseAPI.Entities.Responces;
using BaseAPI.Entities.Results;
using BaseAPI.Util;
using Newtonsoft.Json;

namespace BaseAPI.Business.Authentication
{
    public class LoginBusiness : Business<LoginResponce>,ILoginBusiness
    {
        private readonly MasterToken masterToken;

        public LoginBusiness()
        {
            this.masterToken = new MasterToken();
        }

        public TransactionResponse<LoginResponce> Login(string request)
        {
            TransactionResponse<LoginResponce> response = this.TransactionOk();

            try
            {
                LoginRequest loginRequest = JsonConvert.DeserializeObject<LoginRequest>(request);
                if (loginRequest == null
                    || String.IsNullOrEmpty(loginRequest.DeviceId)
                    || String.IsNullOrEmpty(loginRequest.UserId)
                    || String.IsNullOrEmpty(loginRequest.Password))
                {
                    return this.TransactionFail("Todos los datos son requeridos");
                }

                // Validar user

                response.ResultAuthorization = new ResultAuthorization
                {
                    TokenType = "Bearer",
                    AccessToken = this.masterToken.GenerateJwtToken(loginRequest.UserId),
                };
                response.ResultTransaction.TransactionId = this.masterToken.GetUserIdFromToken(response.ResultAuthorization.AccessToken);
            }
            catch (Exception ex)
            {
                response.ResultTransaction.Code = ResponceCode.InternalServerError;
                response.ResultTransaction.Message = ex.Message;
                response.ResultTransaction.AffectedRecords = 0;
                response.ResultTransaction.TransactionId = "";
            }
            return response;
        }
    }
}
