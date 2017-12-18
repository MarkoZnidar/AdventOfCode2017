using AOC2017.Challenge;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AOC2017Tests
{
    [TestClass]
    public class Day03Tests
    {
        private Day03 day3;

        public Day03Tests()
        {
            day3 = new Day03();
        }

        [TestMethod]
        public void Star1ComputeSteps()
        {
            var input = 1024;
            var matrix = day3.CreateSpiralMatrix(input);

            day3.ComputeSteps(matrix, 1).Should().Be(0);
            day3.ComputeSteps(matrix, 12).Should().Be(3);
            day3.ComputeSteps(matrix, 23).Should().Be(2);
            day3.ComputeSteps(matrix, 1024).Should().Be(31);

        }
    }
}