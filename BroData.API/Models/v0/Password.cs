namespace BroData.API.Models.v0
{
    public class Password : IPassword
    {
        public string password { get; set; }
    }

    public interface IPassword { string password { get; set; } }
}
