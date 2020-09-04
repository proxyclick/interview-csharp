namespace Proxyclick.CSharpInterview.Service.Credentials
{
    public class CredentialEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public CredentialEntity(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}