using NoPandaCode.ApplicationEnvironment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaeserEncryption
{
    [Application(Name = "caeser", Description = "Encrypt or Decrypt a string with Caeser Encryption.")]
    public class CaeserApplication
    {
        [Command(Description = "Encrypt a string with Caeser.", Type = CommandType.DefaultCommand)]
        public void Default()
        {
            var typeInput = GetValue("Type (encrypt/decrypt)", true);
            var dataInput = GetValue("Data", true);
            var keyInput = GetValue("Key", true);

            var result = "";

            int key = 0;
            if (int.TryParse(keyInput, out key))
            {
                if (typeInput.ToLower() == "encrypt")
                {
                    result = Caeser.EncryptString(dataInput, key);
                }
                else if (typeInput.ToLower() == "decrypt")
                {
                    result = Caeser.DecryptString(dataInput, key);
                }
                else
                {
                    Console.WriteLine("Please type in \"encrypt\" or \"decrypt\" as type.");
                    return;
                }
            }
            else
            {
                Console.WriteLine("Please type in a number as key.");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("Result: " + result);
        }

        private string GetValue(string name, bool mustFilledOut = true)
        {
            Console.Write($"{name}: ");
            var value = Console.ReadLine();

            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) && mustFilledOut)
            {
                Console.WriteLine("Please fill out!");
                return GetValue(name, mustFilledOut);
            }

            return value;
        }

        [Command(Description = "Encrypt a string with Caeser.", Type = CommandType.NormalCommand)]
        public void Encrypt(List<string> flags, Dictionary<string, string> options)
        {
            if (flags.Count != 0)
            {
                string message = string.Join(' ', flags);
                int key = 0;
                bool keyGood = false;
                if (options.ContainsKey("key"))
                {
                    keyGood = int.TryParse(options["key"], out key);
                }
                if (keyGood)
                {
                    Console.WriteLine("Result: " + Caeser.EncryptString(message, key));
                }
                else
                {
                    Console.WriteLine("Please type in a number as key.");
                }
            }
        }

        [Command(Description = "Decrypt a string with Caeser.", Type = CommandType.NormalCommand)]
        public void Decrypt(List<string> flags, Dictionary<string, string> options)
        {
            if (flags.Count != 0)
            {
                string message = string.Join(' ', flags);
                int key = 0;
                bool keyGood = false;
                if (options.ContainsKey("key"))
                {
                    keyGood = int.TryParse(options["key"], out key);
                }
                if (keyGood)
                {
                    Console.WriteLine("Result: " + Caeser.DecryptString(message, key));
                }
                else
                {
                    Console.WriteLine("Please type in a number as key.");
                }
            }
        }

        [Command(Description = "Bruteforce a string with Caeser.", Type = CommandType.NormalCommand)]
        public void Bruteforce(List<string> flags, Dictionary<string, string> options)
        {
            if (flags.Count != 0)
            {
                string message = string.Join(' ', flags);
                
                for (int i = 0; i < 25; i++)
                {
                    Console.WriteLine($"{i}: {Caeser.DecryptString(message, i)}");
                }
            }
        }

        [Command(Description = "Prints help.", Type = CommandType.NormalCommand)]
        public void Usage()
        {
            Console.WriteLine("Usage: encrypt/decrypt key=[KEY] [data]");
        }
    }
}
