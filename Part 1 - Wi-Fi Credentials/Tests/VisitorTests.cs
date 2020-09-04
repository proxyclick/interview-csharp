using System.Linq;
using System.Threading.Tasks;
using Proxyclick.CSharpInterview.Service.Visitors;
using Proxyclick.CSharpInterview.Tests.Data;
using Xunit;

namespace Proxyclick.CSharpInterview.Tests
{
    //Do not modify this file
    //TODO make sure all test cases pass
    //Read the description of each test case carefully
    public class VisitorTests
    {
        private readonly IVisitorService _visitorService = new VisitorService();
        
        [Fact]
        public async Task CanFindTyrion()
        {
            var visitors  = await _visitorService.ListVisitors(email: "tyrion@lannister.com", companyName: null);
            var tyrion = Assert.Single(visitors);
            VisitorDataComparer.CompareVisitor(4, tyrion);
        }

        [Fact]
        public async Task CannotFindNedStart()
        {
            var visitors = await _visitorService.ListVisitors(email: "ned@stark.com", companyName: null);
            Assert.NotNull(visitors);
            Assert.Empty(visitors);
        }

        [Fact]
        public async Task CanFindWorkersOnTheWall()
        {
            var nightWatch = (await _visitorService.ListVisitors(email: null, companyName: "The Wall")).ToList();
            Assert.Equal(2, nightWatch.Count);
            VisitorDataComparer.CompareVisitor(2, nightWatch[0]);
            VisitorDataComparer.CompareVisitor(6, nightWatch[1]);
        }

        [Fact]
        public async Task CanFindJonSnow()
        {
            var visitors = await _visitorService.ListVisitors(email: "jon@snow.com", companyName: "The Wall");
            var jon = Assert.Single(visitors);
            VisitorDataComparer.CompareVisitor(2, jon);
        }
    }
}