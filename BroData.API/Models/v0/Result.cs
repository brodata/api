using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BroData.API.Models.v0
{
    public class Result
    {
        Tuple<object, object> res { get; set; }
        bool Status { get; set; }
        object Response { get; set; }
        public Result(object response, bool status)
        {
           
        }
        public Tuple<object, object> Get(object response, bool status)
        {
            if (status == false)
                return new Tuple<object, object>(new Error("TEST"), response);
            if (status == true)
                return new Tuple<object, object>(new Response("TEST"), response);

        }
    }

    public interface IResult
    {

    }
}
