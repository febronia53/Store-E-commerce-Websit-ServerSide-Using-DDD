namespace E_commerce.API.ErrorsHandler
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);

        }

        public int StatusCode { get; set; }
        public string Message { get; set; }


        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "You are made a Bad Request",
                401 => "Sorry, You arn't Authorized",
                404 => "Sorry, Response not found",
                500 => "Sorry, There is a server error occured",
                _ => null
            };
        }
    }
}
