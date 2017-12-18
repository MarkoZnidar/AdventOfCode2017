using System.IO;
using System.Reflection;
using AOC2017.Challenge;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AOC2017Tests
{
    [TestClass]
    public class Day02Tests
    {
        private Day02 day2;

        public Day02Tests()
        {
            day2 = new Day02();
        }

        [TestMethod]
        public void Star1ComputeChecsumTest()
        {
            var input = @"5 1 9 5
                          7 5 3
                          2 4 6 8";

            day2.Checksum1(input).Should().Be(18);
        }

        [TestMethod]
        public void Star2ComputeChecsumTest()
        {
            var input = @"5 9 2 8
                            9 4 7 3
                            3 8 6 5";

            day2.Checksum2(input).Should().Be(9);
        }
    }
}