using BaseAPI.Entities.Responces;

namespace BaseAPI.Business.Interface.Authentication
{
    public interface ILoginBusiness
    {
        TransactionResponse<LoginResponce> Login(string request);
    }
}
