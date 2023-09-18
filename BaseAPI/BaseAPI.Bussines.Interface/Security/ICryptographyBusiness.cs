namespace BaseAPI.Business.Interface.Security
{
    public interface ICryptographyBusiness
    {
        public string Encrypting(string entry);
        public string Decrypting(string entry);
    }
}
