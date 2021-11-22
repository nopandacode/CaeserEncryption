using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using NoPandaCode.ApplicationEnvironment;

namespace CaeserEncryption
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                AppRunner.Run<CaeserApplication>(args[0], args.Skip(1).ToArray());
            }
            else
            {
                AppRunner.Run<CaeserApplication>(null, Array.Empty<string>());
            }
            

            if (ConsoleWillBeDestroyedAtTheEnd())
            {
                Console.WriteLine();
                Console.WriteLine("Press any key to continue . . .");
                Console.ReadLine();
            }
        }

        #region Exit Stuff
        private static bool ConsoleWillBeDestroyedAtTheEnd()
        {
            var processList = new uint[1];
            var processCount = GetConsoleProcessList(processList, 1);

            return processCount == 1;
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern uint GetConsoleProcessList(uint[] processList, uint processCount);
        #endregion
    }
}