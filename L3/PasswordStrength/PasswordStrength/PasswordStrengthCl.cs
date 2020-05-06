using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordStrength
{
    public class PasswordStrengthCl
    {
        static void Main(string[] args)
        {
            if (Check(args) == 0)
            {
                Console.Write(CheckPasswordStrength(args));
                Console.WriteLine(" strength password");
            }
        }

        public static int Check(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Arguments: <password>");
                return 1;
            }

            if(args[0] == "")
            {
                Console.WriteLine("Entered empty string!");
                return 1;
            }

            if(args[0].Contains(' '))
            {
                Console.WriteLine("Space is present!");
                return 1;
            }

            return 0;
        }

        public static int CheckPasswordStrength(string[] args)
        {
            string password = args[0];
            string upLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string lowLetters = "abcdefghijklmnopqrstuvwxyz";
            string numbers = "0123456789";

            for (int i = 0; i < password.Length; i++)
            {
                if (!upLetters.Contains(password[i]) & !lowLetters.Contains(password[i])
                    & !numbers.Contains(password[i]))
                {
                    Console.WriteLine("Password contains invalid characters!");
                    return 1;
                }
            }

            int strength = 0;
            strength += GetStrengthForCount(password);
            strength += GetStrengthForDigit(password, numbers);
            strength += GetStrengthForUpperLetters(password, upLetters);
            strength += GetStrengthForLowerLetters(password, lowLetters);
            strength -= GetStrengthForCountLetters(password, upLetters, lowLetters);
            strength -= GetStrengthForCountNumbers(password, numbers);
            strength -= GetStrengthForRepeatingChar(password);

            return strength;
        }

        public static int GetStrengthForCount(string pas)
        {
            return 4 * pas.Length;
        }
        
        public static int GetStrengthForDigit(string pas, string num)
        {
            int counNum = 0;
            for (int j = 0; j < pas.Length; j++)
            {
                if(num.Contains(pas[j]))
                {
                    counNum++;
                }
            }
            return 4 * counNum;
        }
        
        public static int GetStrengthForUpperLetters(string pas, string upLet)
        {
            int counUpLet = 0;
            for(int j = 0; j < pas.Length; j++)
            {
                if(upLet.Contains(pas[j]))
                {
                    counUpLet++;
                }
            }
            return (pas.Length - counUpLet) * 2;
        }
    
        public static int GetStrengthForLowerLetters(string pas, string lowLet)
        {
            int countLowLet = 0;
            for(int j = 0; j < pas.Length; j++)
            {
                if(lowLet.Contains(pas[j]))
                {
                    countLowLet++;
                }
            }
            return (pas.Length - countLowLet) * 2;
        }

        public static int GetStrengthForCountLetters(string pas, string upLet, 
            string lowLet)
        {
            int countLet = 0;
            for(int j = 0; j < pas.Length; j++)
            {
                if(upLet.Contains(pas[j]) | lowLet.Contains(pas[j]))
                {
                    countLet++;
                }
            }

            if(pas.Length == countLet)
            {
                return countLet;
            }
            return 0;
        }
        
        public static int GetStrengthForCountNumbers(string pas, string num)
        {
            int countNum = 0;
            for (int j = 0; j < pas.Length; j++)
            {
                if (num.Contains(pas[j]))
                {
                    countNum++;
                }
            }

            if(pas.Length == countNum)
            {
                return countNum;
            }
            return 0;
        }

        public static int GetStrengthForRepeatingChar(string pas)
        {
            Dictionary<char, int> repeatsCharacters = new Dictionary<char, int>();

            for (int j = 0; j < pas.Length; j++)
            {
                if (repeatsCharacters.ContainsKey(pas[j]))
                {
                    repeatsCharacters[pas[j]] += 1;
                }
                else
                {
                    repeatsCharacters.Add(pas[j], 1);
                }
            }

            int countRepeats = 0;

            foreach (var key in repeatsCharacters)
            {
                if(key.Value > 1)
                {
                    countRepeats += key.Value;
                }
            }

            return countRepeats;
        }
    }
}
