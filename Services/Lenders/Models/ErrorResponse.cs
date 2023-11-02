namespace Lenders.Models
{
    public class ErrorResponse
    {
        public string Message { get; set; }
        public string Detail { get; set; }
        public int StatusCode { get; set; } 
        public string ErrorCode { get; set; } 

    }
}
