namespace BroData.API.Models.v0
{
    public class Surname : ISurname
    {
        public string surname { get; set; }
    }

    public interface ISurname
    {
        string surname { get; set; }
    }
}
