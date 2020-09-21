using BroData.API.Models.v0;
using BroData.API.Service.v0;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BroData.API.Data
{
    public class StatesRepo
    {
        private static List<IState> massiv = new List<IState>();

        public static void Init(string dataset_file_name)
        {

            foreach (string tmp_str in File.ReadAllLines(dataset_file_name))
            {
                try
                {
                    string[] tmp_str_split = tmp_str.Split(',');
                    massiv.Add(new State
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



        public static IEnumerable<IState> GetAll()
        {
            return massiv;
        }
    }
}
