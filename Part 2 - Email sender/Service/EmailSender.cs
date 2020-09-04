using System.Threading.Tasks;

namespace Service
{
    public class EmailSender
    {
        public Task SendEmail(string email, string content)
        {
            return Task.CompletedTask;
        }
    }
}