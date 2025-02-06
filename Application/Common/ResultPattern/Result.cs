namespace E_Commerce.Application.Common.ResultPattern
{

    public class Result<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public T Value { get; set; }
        public Result()
        {
            Errors = new List<string>();
        }

        public static Result<T> Success(T value, string message = "")
        {
            return new Result<T> { IsSuccess = true, Value = value, Message = message };
        }

        // Generate generic failuir response

        public static Result<T> Fail(string message, List<string> errors = null)
        {
            return new Result<T> { IsSuccess = false, Message = message, Errors = errors ?? new List<string>() };
        }

    }
}
