using BroData.API.Brokers;
using BroData.API.Data;
using BroData.API.Models.v0;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace BroData.API.Service.v0
{
    public class GenEmailService : IGenEmailService
    {
        StringBuilder stringBuilder = new StringBuilder();

        public IEmail Get()
        {

            stringBuilder.Append(SurnamesRepo.GetRandom().surname.ToLower());
            stringBuilder.Append("@example.lan");
            return new Email { name = stringBuilder.ToString() };
        }
    }

    public interface IGenEmailService
    {
        IEmail Get();
    }
}
