using System;
using Xunit;
using RemoveExtraBlanks;

namespace RemoveExtraBlanks_Test
{
    public class RemoveExtraBlanksTest
    {
        [Fact]
        public void moreTwoArgs_return_1()
        {
            string[] threeArgs = { "../../input.txt", "../../output.txt", "../../leftFile.txt" };
            int expected = 1;

            int actual = RemoveExtraBlanksCl.CheckArgs(threeArgs);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void oneArg_return_1()
        {
            string[] threeArgs = { "../../input.txt"};
            int expected = 1;

            int actual = RemoveExtraBlanksCl.CheckArgs(threeArgs);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void wrongLocationInputFile_return_1()
        {
            string[] threeArgs = { "../input.txt", "../../output.txt" };
            int expected = 1;

            int actual = RemoveExtraBlanksCl.CheckArgs(threeArgs);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void wrongLocationOutputFile_return_1()
        {
            string[] threeArgs = { "../../input.txt", "../output.txt" };
            int expected = 1;

            int actual = RemoveExtraBlanksCl.CheckArgs(threeArgs);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void emptyLinesArgs_return_1()
        {
            string[] threeArgs = { "", "" };
            int expected = 1;

            int actual = RemoveExtraBlanksCl.CheckArgs(threeArgs);

            Assert.Equal(expected, actual);
        }
    }
}
