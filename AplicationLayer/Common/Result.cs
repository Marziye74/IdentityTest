using System.Net;

namespace AplicationLayer.Common
{
    public class Result
    {
        public string[] Error { get; set; }
        public object? Data { get; set; }
        public bool IsSuccess { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
