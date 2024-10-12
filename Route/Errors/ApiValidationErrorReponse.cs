namespace Store.Route.APIs.Errors
{
    public class ApiValidationErrorReponse : ApiErrorResponse
    {
        public IEnumerable<string> Errors { get; set; } = new List<string>();

        public ApiValidationErrorReponse() : base(400)
        {

        }

    }

}
