namespace Authentication.Backend.Domain.Models
{
    public class User
    {
        /// <summary>
        /// get or set, user id 
        /// </summary>
        /// <value>
        /// UserId, Guid
        /// </value>
        public Guid UserId { get; set; }

        /// <summary>
        /// get or set, user name 
        /// </summary>
        /// <value>
        /// UserName, string
        /// </value>
        public string UserName { get; set; }

        /// <summary>
        /// get or set, user email 
        /// </summary>
        /// <value>
        /// UserEmail, string
        /// </value>
        public string UserEmail { get; set; }

        /// <summary>
        /// get or set, user first name 
        /// </summary>
        /// <value>
        /// UserFirstName, string
        /// </value>
        public string UserFirstName { get; set; }

        /// <summary>
        /// get or set, user last name 
        /// </summary>
        /// <value>
        /// UserLastName, string
        /// </value>
        public string UserLastName { get; set; }

        /// <summary>
        /// get or set, user name 
        /// </summary>
        /// <value>
        /// UserName, string
        /// </value>
        public string UserFullName { get; set; }

        /// <summary>
        /// get or set, user password 
        /// </summary>
        /// <value>
        /// UserPassword, string
        /// </value>
        public string UserPassword { get; set; }

        /// <summary>
        /// get or set, user phone 
        /// </summary>
        /// <value>
        /// UserPhone, string
        /// </value>
        public string UserPhone { get; set; }

        /// <summary>
        /// get or set, user created at 
        /// </summary>
        /// <value>
        /// UserCreatedAt, DateTime
        /// </value>
        public DateTime UserCreatedAt { get; set; }

        /// <summary>
        /// get or set, user updated at 
        /// </summary>
        /// <value>
        /// UserUpdatedAt, DateTime
        /// </value>
        public DateTime UserUpdatedAt { get; set; }

        /// <summary>
        /// get or set, user deleted at 
        /// </summary>
        /// <value>
        /// UserDeletedAt, DateTime
        /// </value>
        public DateTime UserDeletedAt { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public User()
        {
            this.UserId = Guid.NewGuid();
            this.UserName = "";
            this.UserEmail = "";
            this.UserFirstName = "";
            this.UserLastName = "";
            this.UserFullName = "";
            this.UserPassword = "";
            this.UserPhone = "";
            this.UserCreatedAt = DateTime.Now;
            this.UserUpdatedAt = this.UserCreatedAt;
            this.UserDeletedAt = this.UserCreatedAt;
        }

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="userName"></param>
        /// <param name="userEmail"></param>
        /// <param name="userFirstName"></param>
        /// <param name="userLastName"></param>
        /// <param name="userFullName"></param>
        /// <param name="userPassword"></param>
        /// <param name="userPhone"></param>
        /// <param name="userCreatedAt"></param>
        /// <param name="userUpdatedAt"></param>
        /// <param name="userDeletedAt"></param>
        public User(Guid userId, string userName, string userEmail, string userFirstName, string userLastName,
            string userPassword, string userPhone, DateTime userCreatedAt, DateTime userUpdatedAt, DateTime userDeletedAt)
        {
            this.UserId = userId;
            this.UserName = userName;
            this.UserEmail = userEmail;
            this.UserFirstName = userFirstName;
            this.UserLastName = userLastName;
            this.UserFullName = this.UserFirstName +" "+this.UserLastName;
            this.UserPassword = userPassword;
            this.UserPhone = userPhone;
            this.UserCreatedAt = userCreatedAt;
            this.UserUpdatedAt = userUpdatedAt;
            this.UserDeletedAt = userDeletedAt;
        }
    }
}
