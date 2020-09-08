using BroData.API.Models.v0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroData.API.Service.v0
{
    public class GenTelephonService : IGenTelephonService
    {
        public ITelephon Get(string code = null, int? len = null, int count = 1)
        {
            if (count == 1)
                return new Telephon(Gen(code, len));
            List<string> massiv = new List<string>();
            for (int i = 0; i < count; i++)
                massiv.Add(Gen(code, len));
            return new Telephon(massiv);
        }

        
        private string Gen(string code, int? len)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(code ?? "+1");
            sb.Append(" ");

            for (int i = 0; i < 3; i++)
                sb.Append(new Random().Next(0, 9).ToString());
            sb.Append("-");
            for (int i = 0; i < 3; i++)
                sb.Append(new Random().Next(0, 9).ToString());
            sb.Append("-");
            for (int i = 0; i < 4; i++)
                sb.Append(new Random().Next(0, 9).ToString());

            return sb.ToString();
        }
    }

    public interface IGenTelephonService
    {
        ITelephon Get(string code = null, int? len = null, int count = 1);
    }
}
