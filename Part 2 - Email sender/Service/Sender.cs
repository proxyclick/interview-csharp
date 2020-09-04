using System.Threading.Tasks;
using Proxyclick.CSharpInterview.Service.Credentials;

namespace Service
{
    public class Sender
    {
        public Task SendMessage(CredentialEntity credentialEntity, string recipient)
        {
            // TODO: write the content of this function that will send the credentials to a recipient.
            // It should use the EmailSender class as a dummy email sender
            // If the email sender throw an exception, it should retry exactly 4 times with 5 second interval, then stop retrying
            return Task.CompletedTask;
        }
    }
}