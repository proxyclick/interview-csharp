using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Xunit;

namespace Proxyclick.CSharpInterview.Tests.Data
{
    public static class VisitorDataComparer
    {
        //A simple comparison. Usually a deep object compare is used but in the case of this test we'd like you to create the entities.
        public static void CompareVisitor(int visitorId, object visitor)
        {
            var actualVisitorContent = JsonConvert.SerializeObject(visitor).RemoveWhitespace().ToLowerInvariant();
            var expectedVisitorContent = File.ReadAllText($"Data\\Visitor{visitorId}.json").RemoveWhitespace().ToLowerInvariant();
            Assert.Equal(expectedVisitorContent, actualVisitorContent);
        }
        public static string RemoveWhitespace(this string input)
        {
            return new string(input.ToCharArray()
                .Where(c => !Char.IsWhiteSpace(c))
                .ToArray());
        }
    }
}