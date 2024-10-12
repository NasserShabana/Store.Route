namespace Store.Route.APIs.Errors
{
    public class ApiExpectionResponse : ApiErrorResponse
    {
        public string? Details { get; set; }
        public ApiExpectionResponse(int statusCode, string? message = null, string? details = null)
            : base(statusCode, message)
        {
            Details = details;
        }
    }
}
