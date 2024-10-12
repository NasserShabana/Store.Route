namespace Store.Route.APIs.Errors
{
    public class ApiErrorResponse
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }

        public ApiErrorResponse(int statusCode, string? message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        private string? GetDefaultMessageForStatusCode(int statusCode)
        {
            var message =   statusCode switch
            {
                400 => "a Bad Request , You Made It",
                401 => "Unauthorized , You are not authorized",
                404 => "Resource not found",
                500 => "server error",
                _ => null
            };

            return message;
        }

    }
}
