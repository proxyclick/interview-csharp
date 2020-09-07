using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proxyclick.CSharpInterview.Service.Visitors
{
    public interface IVisitorService
    {
        Task<IEnumerable<object>> ListVisitors(string? email, string? companyName);
        Task UpdateVisitor(VisitorUpdateRequest update);

    }
    public class VisitorService : IVisitorService
    {
        //TODO add a valid return type here
        public virtual Task<IEnumerable<object>> ListVisitors(string? email, string? companyName)
        {
            //Make sure to strongly type the visitor return object to match the unit tests
            throw new System.NotImplementedException();
        }

        //Do not touch this method
        public virtual async Task UpdateVisitor(VisitorUpdateRequest update)
        {
            throw new System.NotImplementedException();
        }
    }
}