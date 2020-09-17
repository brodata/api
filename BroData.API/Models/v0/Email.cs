namespace BroData.API.Models.v0
{
    public class Email : IEmail
    {
        public string name { get; set; }
    }
    public interface IEmail
    {
        string name { get; set; }
    }
}
