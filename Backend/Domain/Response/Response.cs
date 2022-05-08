namespace Montrac.API.Domain.Response
{
    public class Response<T>
    {
        public bool Success { get;  set; }
        public string Message { get; set; }
        public T Resource { get; set; }

        public Response(T resource)
        {
            Resource = resource;
            Success = true;
            Message = "Success";
        }

        public Response(string message)
        {
            Success = false;
            Message = message;
        }
    }
}