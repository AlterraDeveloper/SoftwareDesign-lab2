using System;
using System.IO;

namespace SoftwareDesign_lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 4)
            {
                Console.WriteLine("usage : program.exe [FORMAT_FROM] [FORMAT_TO] [PACKAGE_FROM] [PACKAGE_TO]");
            }
            else
            {
                if (!File.Exists(args[2]))
                {
                    Console.WriteLine("Invalid path of [PACKAGE_FROM]");
                }
                else
                {
                    if (args[0].Equals("pcms2", StringComparison.OrdinalIgnoreCase) &&
                        args[1].Equals("krsu", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("Converting...");

                        new Pcms2ToKrsuConverter().Convert(args[2], args[3]);

                        Console.WriteLine("Done");
                    }
                    else
                    {
                        Console.WriteLine("Invalid values of [FORMAT_FROM] or [FORMAT_TO]");
                    }
                }

               
            }
            Console.WriteLine("Press any key to exit...");
            Console.Read();
        }
    }
}
