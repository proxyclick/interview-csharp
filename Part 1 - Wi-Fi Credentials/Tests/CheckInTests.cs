using System;
using System.Threading.Tasks;
using Moq;
using Proxyclick.CSharpInterview.Service.CheckIn;
using Proxyclick.CSharpInterview.Service.Credentials;
using Proxyclick.CSharpInterview.Service.Visitors;
using Xunit;

namespace Proxyclick.CSharpInterview.Tests
{
    //Do not modify this file
    //TODO make sure all test cases pass
    //Read the description of each test case carefully
    public class CheckInTests
    {
        private readonly Mock<VisitorService> _visitorService;
        private readonly Mock<CredentialsService> _credentialService;
        private readonly ICheckInHandler _checkInHandler;

        public CheckInTests()
        {
            _visitorService = new Mock<VisitorService>();
            _visitorService.Setup(x => x.ListVisitors(It.IsAny<string>(), It.IsAny<string>())).CallBase();
            _credentialService = new Mock<CredentialsService>();
            _credentialService.Setup(x => x.Generate(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .CallBase();
            _checkInHandler = new CheckInHandler(_visitorService.Object, _credentialService.Object);
        }

        [Fact]
        public async Task FindVisitorAndGenerateCredentials()
        {
            var @event = new VisitorEntity()
            {
                Email = "dtargaryen@proxyclick.com"
            };

            var result = await _checkInHandler.HandleCheckIn(@event);
            
            Assert.Equal("dtargaryen", result.Username);
            Assert.Equal("308f0103", result.Password);
        }

        [Fact]
        public async Task CanFindVisitorAndResolveMismatch()
        {
            var @event = new VisitorEntity()
            {
                Email = "kdrogo@doth.raki",
                FirstName = "Khal",
                LastName = "Drogo"
            };
            
            var result = await _checkInHandler.HandleCheckIn(@event);
            
            Assert.Equal("kdrogo", result.Username);
            Assert.Equal("81f9d5db", result.Password);

            _visitorService.Verify(x =>
                x.UpdateVisitor(It.Is<VisitorEntity>(s => s.FirstName == "Khal" && s.LastName == "Drogo")), Times.Once);
        }
        
        [Fact]
        public async Task ItShouldStoreCredentialsAndNotStoreItTwice()
        {
            var @event = new VisitorEntity()
            {
                Email = "jon@snow.com",
            };
            
            var result = await _checkInHandler.HandleCheckIn(@event);
            
            Assert.Equal("jsnow", result.Username);
            Assert.Equal("48c2cf16", result.Password);
            
            result = await _checkInHandler.HandleCheckIn(@event);
            
            Assert.Equal("jsnow", result.Username);
            Assert.Equal("48c2cf16", result.Password);


            _credentialService.Verify(x => x.Generate(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()),
                Times.Once);
        }
        
        [Fact]
        public async Task ItShouldThrowAnExceptionIfVisitorNotFound()
        {
            var @event = new VisitorEntity()
            {
                Email = "ned@stark.com",
            };

            var exception = await Assert.ThrowsAsync<Exception>(async () =>
            {
                var result = await _checkInHandler.HandleCheckIn(@event);
            }).ConfigureAwait(false);
        }
        
    }
}