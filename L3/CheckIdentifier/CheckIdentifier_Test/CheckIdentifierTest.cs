using System;
using System.Runtime.InteropServices;
using Xunit;
using CheckIdentifier;
using Xunit.Sdk;

namespace CheckIdentifier_Test
{
    public class CheckIdentifierTest
    {
        [Fact]
        // return 1 - error, return 0 - ok
        public void two_args_return_1()
        {
            string[] str = { "sdvsd", "sdfds", "dsfb" };
            int expected = 1;

            int actual = CheckIdentifierCl.Check(str);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void one_args_return_0()
        {
            string[] str = { "sdvsd" };
            int expected = 0;

            int actual = CheckIdentifierCl.Check(str);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void emptyString_args_return_1()
        {
            string[] str = {""};
            int expected = 1;

            int actual = CheckIdentifierCl.Check(str);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void theseIsASpace_args_return_1()
        {
            string[] str = {"aknfj ak"};
            int expected = 1;

            int actual = CheckIdentifierCl.Check(str);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void unacceptableSymbols_args_return_1()
        {
            string[] str = { "ak+324" };
            int expected = 1;

            int actual = CheckIdentifierCl.Check(str);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void firstDigitCharacter_args_return_1()
        {
            string[] str = { "3dgs" };
            int expected = 1;

            int actual = CheckIdentifierCl.Check(str);

            Assert.Equal(expected, actual);
        }
    }
}
