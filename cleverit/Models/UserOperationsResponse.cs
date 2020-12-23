namespace cleverit.Models
{
    public class UserOperationsResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public UserOperationsResponse(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }
}