﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace print_args
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length == 0)
            {
                Console.WriteLine("No parameters were specified!");
            }
            else
            {
                Console.WriteLine($"Number of arguments: {args.Length}");
                string st = "Arguments:";
                for (int i = 0; i < args.Length; i++)
                {
                    st += $" {args[i]}";
                }
                Console.WriteLine(st);
            }
        }
    }
}
