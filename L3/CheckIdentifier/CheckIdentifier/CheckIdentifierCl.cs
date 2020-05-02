using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIdentifier
{
    public class CheckIdentifierCl
    {
        static void Main(string[] args)
        {
            Check(args);
        }

        public static int Check(string[] args)
        {
            string identifier = args[0];
            string upLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string lowLetters = "abcdefghijklmnopqrstuvwxyz";
            string numbers = "0123456789";

            if (args.Length > 1)
            {
                Console.WriteLine("You entered more than one identifier!");
                return 1;
            }

            if (identifier == "")
            {
                Console.WriteLine("Entered empty string!");
                return 1;
            }

            if (identifier.Contains(' '))
            {
                Console.WriteLine("No.\nIdentifier contains a space!");
                return 1;
            }

            for (int i = 0; i < identifier.Length; i++)
            {
                if ((!numbers.Contains(identifier[i])) & (!lowLetters.Contains(identifier[i]))
                    & (!upLetters.Contains(identifier[i])))
                {
                    Console.WriteLine("No.\nIdentifier contains non-rule characters!");
                    return 1;
                }
            }

            if (numbers.Contains(identifier[0]))
            {
                Console.WriteLine("No.\nCan't start with a number!");
                return 1;
            }

            Console.WriteLine("Yes.");
            return 0;
        }
    }
}
