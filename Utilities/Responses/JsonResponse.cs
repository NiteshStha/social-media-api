namespace Utilities.Responses
{
    public class JsonResponse<T>
    {
        public int StatusCode { get; set; }
        public T Data { get; set; }

        public JsonResponse(int statusCode, T data)
        {
            StatusCode = statusCode;
            Data = data;
        }
    }
}