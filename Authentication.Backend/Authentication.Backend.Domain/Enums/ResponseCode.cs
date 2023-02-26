namespace Authentication.Backend.Domain.Enums
{
    public enum ResponseCode
    {
        /// <summary>
        /// The Switching protocols
        /// </summary>
        SwitchingProtocols = 101,

        /// <summary>
        /// The Ok
        /// </summary>
        Ok = 200,

        /// <summary>
        /// The Bad Request
        /// </summary>
        BadRequest = 400,

        /// <summary>
        /// The Unauthorized
        /// </summary>
        Unauthorized = 401,

        /// <summary>
        /// The Conflict
        /// </summary>
        Conflict = 409,

        /// <summary>
        /// The Internal Server Error
        /// </summary>
        InternalServerError = 500,
    }
}
