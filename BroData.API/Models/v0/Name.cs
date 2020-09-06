using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BroData.API.Models.v0
{
    [Table("dataset_names")]
    public class Name : IName
    {
        public string name { get; set; }
    }

    public interface IName
    {
        string name { get; set; }
    }
}