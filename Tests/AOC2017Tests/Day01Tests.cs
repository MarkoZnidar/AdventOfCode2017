using AOC2017.Challenge;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AOC2017Tests
{
    [TestClass]
    public class Day01Tests
    {
        private Day01 day1;

        public Day01Tests()
        {
            day1 = new Day01();
        }

        [TestMethod]
        public void Star1ComputeCaptchaTest()
        {
            day1.SolveCaptcha("1122", false).Should().Be(3);
            day1.SolveCaptcha("1111", false).Should().Be(4);
            day1.SolveCaptcha("1234", false).Should().Be(0);
            day1.SolveCaptcha("91212129", false).Should().Be(9);
        }

        [TestMethod]
        public void Star2ComputeCaptchaTest()
        {
            day1.SolveCaptcha("1212", true).Should().Be(6);
            day1.SolveCaptcha("1221", true).Should().Be(0);
            day1.SolveCaptcha("123425", true).Should().Be(4);
            day1.SolveCaptcha("123123", true).Should().Be(12);
            day1.SolveCaptcha("12131415", true).Should().Be(4);
        }
    }
}
