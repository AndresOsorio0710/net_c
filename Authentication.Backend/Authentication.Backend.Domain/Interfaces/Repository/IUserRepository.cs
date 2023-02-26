using Authentication.Backend.Domain.Models;

namespace Authentication.Backend.Domain.Interfaces.Repository
{
    public interface IUserRepository :
        IAdd<User>, IDelete<User, Guid>, IEdit<User, Guid>, IGet<User, Guid>, ITransaction
    { 
    }
}
