using System.Threading.Tasks;
using Proxyclick.CSharpInterview.Service.Credentials;
using Proxyclick.CSharpInterview.Service.Visitors;

namespace Proxyclick.CSharpInterview.Service.CheckIn
{
    public interface ICheckInHandler
    {
        /// <summary>
        /// In response to a check-in event returns a Wi-Fi credentials object
        /// </summary>
        /// <param name="visitorEvent">The event of a visitor checking in</param>
        /// <returns>A credentials object, containing the credentials of a visitor</returns>
        Task<CredentialEntity> HandleCheckIn(VisitorUpdateRequest visitorEvent);
    }
    public class CheckInHandler : ICheckInHandler
    {
        private readonly IVisitorService _visitorService;
        private readonly ICredentialService _credentialService;

        public CheckInHandler(IVisitorService visitorService, ICredentialService credentialService)
        {
            _visitorService = visitorService;
            _credentialService = credentialService;
        }
        public Task<CredentialEntity> HandleCheckIn(VisitorUpdateRequest visitorEvent)
        {
            //Make sure to strongly type the return object here 
            throw new System.NotImplementedException();
            
        }
    }
}