using Authentication.Backend.Aplications.Interfaces;
using Authentication.Backend.Domain.Interfaces.Repository;
using Authentication.Backend.Domain.Models;
using Authentication.Backend.Domain.Referentials;
using System.Security.Cryptography.X509Certificates;

namespace Authentication.Backend.Aplications.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public TransactionResponse<User> Add(User entity)
        {
            try
            {
                string validate = this.validateEntity(entity);
                if (!validate.Equals("Ok")) {
                    return ResponseManager.ResponseValidation<User>(validate);
                }
                return this.userRepository.Add(entity);
            }
            catch(Exception ex)
            {
                return ResponseManager.ResponseInternalServerError<User>(ex.Message);
            }
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

        private string validateEntity(User user)
        {
            if (user.UserFirstName.Equals("") || user.UserFirstName == null || user.UserFirstName == string.Empty)
            {
                return "First Name is required.";
            }
            if (user.UserLastName.Equals("") || user.UserLastName == null || user.UserLastName == string.Empty)
            {
                return "Last Name is required.";
            }
            if (user.UserName.Equals("") || user.UserName == null || user.UserName == string.Empty)
            {
                return "Name is required.";
            }
            if (user.UserEmail.Equals("") || user.UserEmail == null || user.UserEmail == string.Empty)
            {
                return "Email is required.";
            }
            if (user.UserPassword.Equals("") || user.UserPassword == null || user.UserPassword == string.Empty)
            {
                return "Password is required.";
            }
            return "Ok";
        }
    }
}
