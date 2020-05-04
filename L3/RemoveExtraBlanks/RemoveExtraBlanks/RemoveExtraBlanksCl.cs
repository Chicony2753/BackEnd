using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace RemoveExtraBlanks
{
    public class RemoveExtraBlanksCl
    {
        static void Main(string[] args)
        {
            if(CheckArgs(args) == 0)
            {
                Remove(args);
            }
        }

        public static int CheckArgs(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Arguments: <path to input file> <path to output file>");
                return 1;
            }

            if (!File.Exists(args[0]))
            {
                Console.WriteLine("Input file not found!");
                return 1;
            }

            if (!File.Exists(args[1]))
            {
                Console.WriteLine("Output file not found!");
                return 1;
            }

            return 0;
        }

        public static int Remove(string[] args)
        {
            string[] text_input = File.ReadAllLines(args[0]);

            for(int i = 0; i < text_input.Length; i++)
            {
                text_input[i] = text_input[i].Trim();
                text_input[i] = Regex.Replace(text_input[i], "[ ]+", " ");
            }

            File.WriteAllLines(args[1], text_input);

            return 0;
        }
    }
}
