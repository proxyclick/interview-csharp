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
            // If the email sender throws an exception, it should retry exactly 4 times with a 10 minute interval, then stop retrying
            return Task.CompletedTask;
        }
    }
}