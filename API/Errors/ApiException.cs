namespace API.Errors
{
    public class ApiException(int stausCode, string message, string? details)
    {
        public int StatusCode { get; set; } = stausCode;
        public string Messaga { get; set; } = message;
        public string? Details { get; set; } = details;
    }
}
