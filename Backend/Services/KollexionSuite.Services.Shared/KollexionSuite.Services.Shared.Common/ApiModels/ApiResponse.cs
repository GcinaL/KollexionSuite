namespace KollexionSuite.Services.Shared.Common.ApiModels
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public T? Data { get; set; }
        public ApiError? Error { get; set; }

        public static ApiResponse<T> Ok(T data) =>
            new ApiResponse<T> { Success = true, Data = data };

        public static ApiResponse<T> Fail(string message, int statusCode, object? details = null) =>
            new ApiResponse<T>
            {
                Success = false,
                Error = new ApiError
                {
                    Message = message,
                    StatusCode = statusCode,
                    Details = details
                }
            };
    }
    public class ApiError
    {
        public string Message { get; set; } = string.Empty;
        public int StatusCode { get; set; }
        public object? Details { get; set; }
    }
}
