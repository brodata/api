using BroData.API.Models.v0;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BroData.API.Datasets
{
    public static class ISO3166Repo
    { 

        private static List<IISO3166> massiv = new List<IISO3166>();

        public static void Init(string dataset_file_name)
        {
            
            foreach (string tmp_str in File.ReadAllLines(dataset_file_name))
            {
                try
                {
                    string[] tmp_str_split = tmp_str.Split(';');
                    massiv.Add(new ISO3166
                    {
                        name = tmp_str_split[1],
                        alpha_2 = tmp_str_split[2],
                        alpha_3 = tmp_str_split[3],
                        country_code = Convert.ToInt32(tmp_str_split[4]),
                        iso_3166_2 = tmp_str_split[5],
                        region = tmp_str_split[6],
                        sub_region = tmp_str_split[7],
                        intermediate_region = tmp_str_split[8],
                        region_code = Convert.ToInt32(tmp_str_split[9]),
                        sub_region_code = Convert.ToInt32(tmp_str_split[10]),
                        intermediate_region_code = Convert.ToInt32(tmp_str_split[11]),
                        cctld = tmp_str_split[12],
                        imgurls = tmp_str_split[13],
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

        

        public static IEnumerable<IISO3166> GetAll()
        {
            return massiv;
        }

        public static IEnumerable<IISO3166> GetByAlpha2(string alpha_2)
        {
            return massiv.Where(x => x.alpha_2 == alpha_2);
        }

        public static IEnumerable<IISO3166> GetByAlpha3(string alpha_3)
        {
            return massiv.Where(x => x.alpha_3 == alpha_3);
        }

        
    }

    public interface IISO3166Repo
    {
        IEnumerable<IISO3166> GetAll();
        IEnumerable<IISO3166> GetByAlpha2(string alpha_2);
        IEnumerable<IISO3166> GetByAlpha3(string alpha_3);
    }
}
