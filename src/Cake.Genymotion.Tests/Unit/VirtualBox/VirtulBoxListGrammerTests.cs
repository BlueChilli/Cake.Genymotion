using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xunit;

namespace Cake.Genymotion.Tests.Unit.VirtualBox
{
    public class VirtulBoxListGrammerTests
    {

        [Fact]
        public void Parse_ShouldParseUUID_GivenALine()
        {
            
            var regex = new Regex(@"(?<=\{).+?(?=\})");

           var match = regex.Match("\"Samsung Galaxy S4 - 4.2.2 - API 17 - 1080x1920\" {cc293d38-9187-4c55-9f47-f4b8faf58c4b}");

            Assert.Equal("cc293d38-9187-4c55-9f47-f4b8faf58c4b",  match.Value);

        }

         [Fact]
        public void Parse_ShouldParseName_GivenALine()
        {
            
            var regex = new Regex(String.Format(@"(?<=\{0}).+?(?=\{1})",  "\"", "\""));

           var match = regex.Match("\"Samsung Galaxy S4 - 4.2.2 - API 17 - 1080x1920\" {cc293d38-9187-4c55-9f47-f4b8faf58c4b}");

            Assert.Equal("Samsung Galaxy S4 - 4.2.2 - API 17 - 1080x1920",  match.Value);

        }
    }
}
