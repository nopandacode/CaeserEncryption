using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaeserEncryption
{
    public class Caeser
    {
        private static Dictionary<int, char> alphabet = new Dictionary<int, char>()
    {
        { 0, 'A' },
        { 1, 'B' },
        { 2, 'C' },
        { 3, 'D' },
        { 4, 'E' },
        { 5, 'F' },
        { 6, 'G' },
        { 7, 'H' },
        { 8, 'I' },
        { 9, 'J' },
        { 10, 'K' },
        { 11, 'L' },
        { 12, 'M' },
        { 13, 'N' },
        { 14, 'O' },
        { 15, 'P' },
        { 16, 'Q' },
        { 17, 'R' },
        { 18, 'S' },
        { 19, 'T' },
        { 20, 'U' },
        { 21, 'V' },
        { 22, 'W' },
        { 23, 'X' },
        { 24, 'Y' },
        { 25, 'Z' },
    };
        private static char[] specialChars = { ' ', '.', ',', '!', '?', '-', '_', '"', '§', '$', '%', '&', '{' , '(', '[', ']', ')', '}', '=', '/', '\\' };

        /// <summary>
        /// Encrypt a string with the Caeser Encryption
        /// </summary>
        /// <param name="rawData">The raw data.</param>
        /// <param name="key">The key</param>
        /// <returns>A encrypted string</returns>
        /// <exception cref="KeyNotFoundException" />
        public static string EncryptString(string rawData, int key)
        {
            string retval = "";

            rawData = rawData.ToUpper();

            foreach (var ch in rawData)
            {
                if (specialChars.Contains(ch))
                {
                    retval += specialChars.Where(chr => chr == ch).FirstOrDefault();
                    continue;
                }
                int index = alphabet.IndexOf(ch);
                int newIndex = index + key;
                char newChar = '?';

                if (newIndex >= alphabet.Count)
                {
                    newChar = alphabet[newIndex - alphabet.Count];
                }
                else
                {
                    newChar = alphabet[newIndex];
                }

                retval += newChar;
            }

            return retval;
        }
        /// <summary>
        /// Decrypyt a string with the Caeser Decryption
        /// </summary>
        /// <param name="encryptedData">The encrypted data.</param>
        /// <param name="key">The key</param>
        /// <returns>A decrypted string</returns>
        /// <exception cref="KeyNotFoundException" />
        public static string DecryptString(string encryptedData, int key)
        {
            string retval = "";

            encryptedData = encryptedData.ToUpper();

            foreach (var ch in encryptedData)
            {
                if (specialChars.Contains(ch))
                {
                    retval += specialChars.Where(chr => chr == ch).FirstOrDefault();
                    continue;
                }
                int index = alphabet.IndexOf(ch);
                int newIndex = index - key;
                char newChar = '?';

                if (newIndex != 0 && (newIndex >= -alphabet.Count && newIndex < 0))
                {
                    newChar = alphabet[newIndex + alphabet.Count];
                }
                else
                {
                    newChar = alphabet[newIndex];
                }

                retval += newChar;
            }

            return retval;
        }
    }

    static class DictionaryExtensions
    {
        public static int IndexOf<TValue>(this Dictionary<int, TValue> dict, TValue? val)
        {
            foreach (var kv in dict)
            {
                if (val != null && kv.Value.Equals(val))
                {
                    return kv.Key;
                }
            }
            return -1;
        }
    }
}
