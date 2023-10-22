namespace MedicationAPI.Models
{
    public class Response<ResultType>
    {
        public ResultType Result { get; set; }

        public int StatusCode;
        public string ErrorMessage;

        public Response(ResultType result)
        {
            StatusCode = 200;
            Result = result;
        }

        public Response(int statusCode)
        {
            StatusCode = statusCode;
        }

        public Response(int statusCode, string errorMessage)
        {
            StatusCode = statusCode;
            ErrorMessage = errorMessage;
        }

        public Response(int statusCode, ResultType result, string errorMessage)
        {
            StatusCode = statusCode;
            ErrorMessage = errorMessage;
            Result = result;
        }

        public Response(int statusCode, ResultType result)
        {
            StatusCode = statusCode;
            Result = result;
        }
    }
}