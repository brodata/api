using BroData.API.Models.v0;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BroData.API.Data
{
    public class CitiesRepo
    {
        private static List<ICity> massiv = new List<ICity>();

        public static void Init(string dataset_file_name)
        {

            foreach (string tmp_str in File.ReadAllLines(dataset_file_name))
            {
                try
                {
                    string[] tmp_str_split = tmp_str.Split(',');
                    massiv.Add(new City
                    {
                        id = Convert.ToInt32(tmp_str_split[0]),
                        state_code = StatesRepo.GetAll()
                        .Where(x => x.id == Convert.ToInt32(tmp_str_split[1]))
                        .First().code,
                        city = tmp_str_split[2],
                        county = tmp_str_split[3],
                        latitude = float.Parse(tmp_str_split[4]),
                        longitude = float.Parse(tmp_str_split[5]),
                    });

                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Error ICity: ");
                    Console.ResetColor();
                    Console.WriteLine(e.Message);

                }
            }
        }



        public static IEnumerable<ICity> GetAll()
        {
            return massiv;
        }
    }
}
