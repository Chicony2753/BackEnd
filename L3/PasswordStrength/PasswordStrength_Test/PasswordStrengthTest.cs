using System;
using Xunit;
using PasswordStrength;

namespace PasswordStrength_Test
{
    public class PasswordStrengthTest
    {
        [Fact]
        public void moreOneArgument_return_1()
        {
            string[] str = { "empty12pass", "emptypass21l" };
            int expected = 1;
            
            int actual = PasswordStrengthCl.Check(str);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void emptyString_return_1()
        {
            string[] str = { "" };
            int expected = 1;

            int actual = PasswordStrengthCl.Check(str);

            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void containsSpace_return_1()
        {
            string[] str = { "empty pass" };
            int expected = 1;

            int actual = PasswordStrengthCl.Check(str);

            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void containsInvalidChar_return_1()
        {
            string[] str = { "17812emptypass^^" };
            int expected = 1;

            int actual = PasswordStrengthCl.CheckPasswordStrength(str);

            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void lenPassword_multiplyByFour_return_44()
        {
            string password = "17812emptypass";
            int expected = 56;

            int actual = PasswordStrengthCl.GetStrengthForCount(password);

            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void countDigit_multiplyByFour_return_20()
        {
            string numbers = "0123456789";
            string password = "17812emptypass";
            int expected = 20;

            int actual = PasswordStrengthCl.GetStrengthForDigit(password, numbers);

            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void lenPassword_minusCountUpperLetters_multiplyByTwo_return_22()
        {
            string upLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string password = "17812emptyPASS";
            int expected = 20;

            int actual = PasswordStrengthCl.GetStrengthForUpperLetters(password, upLetters);

            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void lenPassword_minusCountLowerLetters_multiplyByTwo_return_18()
        {
            string lowLetters = "abcdefghijklmnopqrstuvwxyz";
            string password = "17812emptyPASS";
            int expected = 18;

            int actual = PasswordStrengthCl.GetStrengthForLowerLetters(password, lowLetters);

            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void passwordForLetters_return_17()
        {
            string upLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string lowLetters = "abcdefghijklmnopqrstuvwxyz";
            string password = "emptyPASS";
            int expected = 9;

            int actual = PasswordStrengthCl.GetStrengthForCountLetters(password, upLetters, lowLetters);

            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void singleDigitPassword_return_0()
        {
            string upLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string lowLetters = "abcdefghijklmnopqrstuvwxyz";
            string password = "empty123PASS";
            int expected = 0;

            int actual = PasswordStrengthCl.GetStrengthForCountLetters(password, upLetters, lowLetters);

            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void singleLetterPasswrod_return_0()
        {
            string numbers = "0123456789";
            string password = "289241s63215";
            int expected = 0;

            int actual = PasswordStrengthCl.GetStrengthForCountNumbers(password, numbers);

            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void countRepeatingChar_return_7()
        {
            string password = "hellohell";
            int expected = 8;

            int actual = PasswordStrengthCl.GetStrengthForRepeatingChar(password);

            Assert.Equal(expected, actual);
        }

    }
}
