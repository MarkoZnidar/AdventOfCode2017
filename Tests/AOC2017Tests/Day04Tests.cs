using AOC2017.Challenge;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AOC2017Tests
{
    [TestClass]
    public class Day04Tests
    {
        private Day04 day4;

        public Day04Tests()
        {
            day4 = new Day04();
        }

        [TestMethod]
        public void ReadInputFromFileTest()
        {
            var fileName = "Day4TestInput.txt";
            var input = day4.ReadInputFromFile(fileName);
            input.Count.Should().Be(3);

            input[0].Should().Be("aa bb cc dd ee");
            input[1].Should().Be("aa bb cc dd aa");
            input[2].Should().Be("aa bb cc dd aaa");

        }

        [TestMethod]
        public void IsLineValidTest()
        {
            var fileName = "Day4TestInput.txt";
            var input = day4.ReadInputFromFile(fileName);
            input.Count.Should().Be(3);

            day4.isValidPassphraseLine(input[0]).Should().Be(true);
            day4.isValidPassphraseLine(input[1]).Should().Be(false);
            day4.isValidPassphraseLine(input[2]).Should().Be(true);
        }

        [TestMethod]
        public void CountValidPassphrasesTest()
        {
            var fileName = "Day4TestInput.txt";
            var input = day4.ReadInputFromFile(fileName);
            input.Count.Should().Be(3);

            day4.CountValidPassphrases(input).Should().Be(2);
        }


        [TestMethod]
        public void IsLineAdvancedValidTest()
        {
            var fileName = "Day4-2TestInput.txt";
            var input = day4.ReadInputFromFile(fileName);
            input.Count.Should().Be(5);

            day4.isValidAdvancedPassphraseLine(input[0]).Should().Be(true);
            day4.isValidAdvancedPassphraseLine(input[1]).Should().Be(false);
            day4.isValidAdvancedPassphraseLine(input[2]).Should().Be(true);
            day4.isValidAdvancedPassphraseLine(input[3]).Should().Be(true);
            day4.isValidAdvancedPassphraseLine(input[4]).Should().Be(false);

        }

        [TestMethod]
        public void CountValidAdvanedPassphrasesTest()
        {
            var fileName = "Day4-2TestInput.txt";
            var input = day4.ReadInputFromFile(fileName);
            input.Count.Should().Be(5);

            day4.CountAdvancedValidPassphrases(input).Should().Be(3);
        }

        [TestMethod]
        public void CountAdvanedPassphrasePolicyTest()
        {
            var fileName = "Day4-2TestInput.txt";
            var input = day4.ReadInputFromFile(fileName);
            input.Count.Should().Be(5);

            day4.CountAdvanedPassphrasePolicy(input).Should().Be(3);
        }



    }
}