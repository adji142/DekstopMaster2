using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace ISA.Pin
{
    public class Generator
    {
        private static string GetNumbers(string text)
        {
            string defNumbers = "47144165";

            try
            {
                string numbers = string.Empty;

                for (int pos = 0; pos < text.Length; pos++)
                {
                    if (Char.IsDigit(text[pos]))
                        numbers += text[pos];
                }

                numbers = numbers.Trim();
                if (numbers.Length >= defNumbers.Length)
                    numbers = numbers.Substring(0, defNumbers.Length);
                else
                {
                    int diff = defNumbers.Length - numbers.Length;
                    for (int counter = 0; counter < diff; counter++)
                        numbers += "0";
                }

                return numbers;
            }
            catch { return defNumbers; }
        }

        public static string CreateKey(string prefix, int numDigits)
        {
            int minValue = int.Parse("1".PadRight(numDigits, '0'));
            int maxValue = minValue * 10 - 1;

            Random random = new Random();

            int randomNumber = random.Next(minValue, maxValue);

            return prefix + randomNumber.ToString();
        }

        public static string CreateKey(string prefix)
        {
            return CreateKey(prefix, 4);
        }

        public static string CreateKey(string orgCode, int pinCode, DateTime today)
        {
            string key = orgCode + pinCode.ToString().Trim() +today.ToString("yyMMdd");

            char[] chars = key.ToCharArray();
            Array.Reverse(chars);

            return new string(chars);
        }

        public static string CreatePin(string key)
        {
            MD5 md5Hash = MD5.Create();

            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(key));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            string pinNumber = GetNumbers(sBuilder.ToString().ToUpper());

            return pinNumber;
        }

        public static bool VerifyPin(string key, string pin)
        {
            string pinNumber = CreatePin(key);

            return pin == pinNumber;
        }
    }
}
