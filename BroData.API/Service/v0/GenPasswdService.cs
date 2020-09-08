using BroData.API.Models.v0;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroData.API.Service.v0
{
    public class GenPasswdService : IGenPasswdService
    {
        public IPasswd Get(int count, int _length, int[] mask)
        {
            if (count == 1)
                return new Passwd(new PasswordGenerator(_length, mask).GetPassword());
            List<string> massiv = new List<string>();
            for(int i = 0; i < count; i++)
                massiv.Add(new PasswordGenerator(_length, mask).GetPassword());
            return new Passwd(massiv);
        }
    }

    public interface IGenPasswdService
    {
        IPasswd Get(int count, int _length, int[] mask);

    }

    public class PasswordGenerator
    {
        private const int GenCharArrayCount = 512;
        private int Length { get; set; }
        private bool Number { get; set; }
        private bool Lower { get; set; }
        private bool Upper { get; set; }
        private bool SpecialSymbols { get; set; }

        public PasswordGenerator(int _length, int[] mask)
        {
            
            this.Length = _length;
            Number = mask[0] == 0 ? false : true;
            Lower = mask[1] == 0 ? false : true;
            Upper = mask[2] == 0 ? false : true;
            SpecialSymbols = mask[3] == 0 ? false : true;
        }


        private string PassGen()
        {
            StringBuilder sb = new StringBuilder();

            do
            {
                Collection<char> charArray = StrongGenCharArray();
                Random _random = new Random();

                int x, y;
                char temp;

                for (int i = 0; i < charArray.Count; i++)
                {
                    x = _random.Next(charArray.Count);
                    y = _random.Next(charArray.Count);

                    temp = charArray[x];
                    charArray[x] = charArray[y];
                    charArray[y] = temp;
                }

                for (int i = 0; i < Length; i++)
                    sb.Append(charArray[_random.Next(charArray.Count)]);

            } while (!CheckPassword(sb.ToString()));

            return sb.ToString();

        }

        private Collection<char> StrongGenCharArray()
        {
            Collection<char> charArray = new Collection<char>();
            Random _random = new Random();


            for (int i = 0; i < GenCharArrayCount; i++)
            {
                if (this.Number)
                    charArray.Add((char)_random.Next(48, 57));

                if (this.Upper)
                    charArray.Add((char)_random.Next(65, 90));

                if (this.Lower)
                    charArray.Add((char)_random.Next(97, 122));

                if (this.SpecialSymbols)
                {
                    byte[] _spec_chars = { 33, 35, 36, 37, 40, 41, 91, 93, 95, 123, 125 };
                    charArray.Add((char)_spec_chars[_random.Next(_spec_chars.Length)]);
                }
            }

            return charArray;
        }

        private bool CheckPassword(string _pass)
        {
            bool[] controlTest = { this.Number, this.Lower, this.Upper, this.SpecialSymbols };
            bool[] test = { false, false, false, false };

            List<char> massiv = new List<char>(_pass);
            List<char> massivNumber = new List<char>();
            List<char> massivUpper = new List<char>();
            List<char> massivLower = new List<char>();
            List<char> massivSpecialSymbols = new List<char>();

            byte[] _chars = { 33, 35, 36, 37, 40, 41, 91, 93, 95, 123, 125 };

            for (byte i = 48; i <= 57; i++)
                massivNumber.Add((char)i);

            for (byte i = 65; i <= 90; i++)
                massivUpper.Add((char)i);

            for (byte i = 97; i <= 122; i++)
                massivLower.Add((char)i);

            foreach (char tmp in _chars)
                massivSpecialSymbols.Add(tmp);

            foreach (char tmp in massivNumber)
                if (massiv.Contains(tmp))
                    test[0] = true;

            foreach (char tmp in massivLower)
                if (massiv.Contains(tmp))
                    test[1] = true;

            foreach (char tmp in massivUpper)
                if (massiv.Contains(tmp))
                    test[2] = true;

            foreach (char tmp in massivSpecialSymbols)
                if (massiv.Contains(tmp))
                    test[3] = true;

            if (test.SequenceEqual(controlTest))
                return true;
            else
                return false;

        }


        public string GetPassword() => PassGen();
    }
}
