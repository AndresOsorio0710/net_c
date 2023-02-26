using Authentication.Backend.Domain.Models;

namespace Authentication.Backend.Domain.Request
{
    public class UserRequest : User
    {
        /// <summary>
        /// Get or Set, new password
        /// </summary>
        public string NewPassword { get; set; }

        /// <summary>
        /// Get or Set, confirm password
        /// </summary>
        public string ConfirmPassword { get; set; }
    }
}
