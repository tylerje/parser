using Parser;
using System;

namespace ParserTests
{
    public class ParserBracketTests
    {

        /*
            Test string - Expected result
            <> - True
            >< - False (closed bracket can't proceed all open brackets.)
            <<> - False (one bracket pair was not closed)
            "" - True. (no brackets in the string will return True) 
            <abc...xyz> - True (non-bracket characters are ignored appropriately)     
         */


        [Fact]
        public void AngleBracketsGoodTest()
        {
            //Arrange
            ICodeParser parser = new CodeParser();
            var text = "<>";
            var openingBracket = '<';
            var closingBracket = '>';

            //Act
            var result = parser.AreBracketsClosed(text, openingBracket, closingBracket);

            //Assert
            Assert.True(result.allClosed);
            Assert.Equal(0, result.failedIndex);
        }

        [Theory]
        [InlineData("<>", '<', '>', true, 0)]
        [InlineData("><", '<', '>', false, 0)]
        [InlineData("<<>", '<', '>', false, 0)]
        [InlineData("", '<', '>', true, 0)]
        [InlineData("<abc...xyz>", '<', '>', true, 0)]
        public void BracketsTheoryTests(string text, char openingBracket, char closingBracket, bool expectedResult, int expectedIndex)
        {
            //Arrange
            ICodeParser parser = new CodeParser();

            //Act
            var result = parser.AreBracketsClosed(text, openingBracket, closingBracket);

            //Assert
            Assert.Equal(expectedResult, result.allClosed);
            Assert.Equal(expectedIndex, result.failedIndex);
        }
    }
}