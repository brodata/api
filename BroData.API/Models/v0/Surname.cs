namespace BroData.API.Models.v0
{
    public class Surname : ISurname
    {
        public string surname { get; set; }
        private string country { get; set; }

        public Surname(string surname, string country)
        {
            this.surname = surname;
            this.country = country;
        }

        public string GetCountry()
        {
            return country;
        }
    }

    public interface ISurname
    {
        string surname { get; set; }
    }
}
