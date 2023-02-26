using Authentication.Backend.Domain.Interfaces.Repository;
using Authentication.Backend.Domain.Models;
using Authentication.Backend.Domain.Referentials;
using Authentication.Backend.Infrastructure.Data.Contexts;

namespace Authentication.Backend.Infrastructure.Data.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private BackendContext backendContext;

        public UserRepository(BackendContext backendContext) { 
            this.backendContext = backendContext;
        }

        public TransactionResponse<User> Add(User entity)
        {
            throw new NotImplementedException();
        }

        public TransactionResponse<User> Delete(Guid entityID)
        {
            throw new NotImplementedException();
        }

        public TransactionResponse<User> Edit(User entity, Guid entityID)
        {
            throw new NotImplementedException();
        }

        public TransactionResponse<User> Get(Guid entityID)
        {
            throw new NotImplementedException();
        }

        public TransactionResponse<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public void SaveAllChanges()
        {
            throw new NotImplementedException();
        }
    }
}
