using Authentication.Backend.Domain.Interfaces;
using Authentication.Backend.Domain.Models;

namespace Authentication.Backend.Aplications.Interfaces
{
    public interface IUserService :
        IAdd<User>, IDelete<User, Guid>, IEdit<User, Guid>, IGet<User, Guid>
    {
    }
}
