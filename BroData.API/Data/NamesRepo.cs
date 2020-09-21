using BroData.API.Models.v0;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BroData.API.Data
{
    public class NamesRepo
    {
        private static List<IName> massiv = new List<IName>();

        public static void Init(string dataset_file_name)
        {

            foreach (string tmp_str in File.ReadAllLines(dataset_file_name))
            {
                try
                {
                    string[] tmp_str_split = tmp_str.Split(',');
                    massiv.Add(new Name
                    {
                        name = tmp_str_split[1]
                    });

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



        public static IEnumerable<IName> GetAll()
        {
            return massiv;
        }
    }
}
