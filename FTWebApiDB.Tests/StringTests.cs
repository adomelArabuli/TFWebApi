using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFWebApi.Data;

namespace FTWebApiDB.Tests
{
    public class StringTests
    {
        [Fact]
        public void ConcatTwoStrings_GivenTwoStrings_ReturnsConcanenated()
        {
            StringFunctions stringTests = new StringFunctions();

            string result = stringTests.ConcatenateStrings("Hello ", "world");

            Assert.Equal("Hello world", result);
        }

        [Theory]
        [InlineData("radar", true)]
        [InlineData("test", false)]
        [InlineData("anna", true)]
        [InlineData("no", false)]
        public void IsPalindrome_WhenGivenString_ReturnsResult(string str, bool expectedResult)
        {
            StringFunctions stringFunctions = new StringFunctions();

            var result = stringFunctions.IsPalindrome(str);

            Assert.Equal(expectedResult, result);
        }
    }
}
