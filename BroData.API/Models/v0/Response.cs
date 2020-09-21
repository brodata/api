namespace BroData.API.Models.v0
{
    public class Response<T> : IResponse<T>
    {
        public object response { get; set; }

        public Response(object t) => response = t;
    }

    public interface IResponse<T> { object response { get; set; } }
}
