using System;
using System.Linq;
using Xunit;
using DiceShow;


namespace DiceShow.Tests
{
    public class ParserTests
    {

        [Theory]
        
        [InlineData("2d6", "2d6")]
        [InlineData("2D6", "2d6")]
        [InlineData("str 3d6 dex 3d6", "str 3d6, dex 3d6")]
        [InlineData("2d4 2d6 2d8", "2d4, 2d6, 2d8")]
        [InlineData("2d4,2d6,2d8", "2d4, 2d6, 2d8")]
        [InlineData("2d4, 2d6, 2d8", "2d4, 2d6, 2d8")]
        public void can_parse_valid_input(string raw, string expected)
        {
            var parser = new Parser();

            var parsed = parser.Parse(raw);

            Assert.True(parsed.Statement != null, $"Parsing Errors = {string.Join(", ", parsed.Errors)}\nParsing Exception = {parsed.Exception}");
            Assert.Equal(expected, parsed.Statement.ToString());
        }

        [Theory]
        [InlineData("")]
        public void report_parsing_errors(string raw)
        {

            var parser = new Parser();

            var parsed = parser.Parse(raw);

            Assert.True(parsed.Exception != null, $"");

        }


    }
}

