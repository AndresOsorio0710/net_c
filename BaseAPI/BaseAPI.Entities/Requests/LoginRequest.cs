namespace BaseAPI.Entities.Requests
{
    public class LoginRequest
    {
        public string DeviceId { get; set; }
        public string Password { get; set; }
        public string UserId { get; set; }
    }
}