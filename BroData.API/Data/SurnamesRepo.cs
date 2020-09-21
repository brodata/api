using BroData.API.Models.v0;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BroData.API.Data
{
    public class SurnamesRepo
    {
        private static List<Surname> massiv = new List<Surname>();

        public static void Init(string dataset_file_name)
        {

            foreach (string tmp_str in File.ReadAllLines(dataset_file_name))
            {
                try
                {
                    string[] tmp_str_split = tmp_str.Split(',');

                    massiv.Add(new Surname(tmp_str_split[1], tmp_str_split[2]));

                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Error: ");
                    Console.ResetColor();
                    Console.WriteLine(e.Message);

                }
            }
        }



        public static ISurname GetRandom()
        {
            return massiv[new Random().Next(0, massiv.Count - 1)];
        }

        public static ISurname GetGetByCountry(string country)
        {
            List<Surname> tmp = massiv.FindAll(x => x.GetCountry() == country);

            return tmp[new Random().Next(0, tmp.Count - 1)];
        }
    }
}
