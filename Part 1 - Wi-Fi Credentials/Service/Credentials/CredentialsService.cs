using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Proxyclick.CSharpInterview.Service.Credentials
{
    public interface ICredentialService
    {
        CredentialEntity Generate(string firstName, string lastName, string email);
    }
    public class CredentialsService : ICredentialService
    {
        private const string Key = "872184621648718956589728789";
        private static HMACSHA256 _sha256 = new HMACSHA256(Encoding.Default.GetBytes(Key));
        
        public virtual CredentialEntity Generate(string firstName, string lastName, string email)
        {
            var hash = _sha256.ComputeHash(Encoding.UTF8.GetBytes($"{firstName}{lastName}{email}"));
            return new CredentialEntity($"{firstName.ToLowerInvariant()[0]}{lastName.ToLowerInvariant()}",
                BitConverter.ToString(hash).Replace("-",string.Empty).Substring(0, 8).ToLowerInvariant());
        }
    }
}