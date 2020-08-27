using BroData.API.Models.v0;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BroData.API.Service.v0
{
    public class BroNameService : IBroNameService
    {
        private List<string> massiv = File.ReadAllLines(@"C:\Users\ruhex\Documents\name.txt").ToList();
        public IBroName Name
        {
            get => new BroName(massiv[new Random().Next(0, massiv.Count)]);

        }
    }

    public interface IBroNameService
    {
        IBroName Name { get; }
    }
}
