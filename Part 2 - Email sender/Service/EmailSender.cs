using System.Threading.Tasks;

namespace Service
{
    public class EmailSender
    {
        public Task SendEmail(string email, string content)
        {
            //You shouldn't need to touch this method
            return Task.CompletedTask;
        }
    }
}