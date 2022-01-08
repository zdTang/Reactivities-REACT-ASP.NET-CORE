namespace Application.Core
{
    /// <summary>
    /// This is used for representing Result of WEB API REQUEST
    /// </summary>
    /// <typeparam name="T"></typeparam>
    // Pay attention to this CLASS
    // class is not static, but two methods are static
    public class Result<T>
    {
        public bool IsSuccess { get; set; }
        public T Value { get; set; }
        public string Error { get; set; }
        
        // Here using two static method to create instance. I don't like this approach
        // it is not straight forward.
        public static Result<T> Success(T value)=>new Result<T> { IsSuccess = true, Value = value };
        public static Result<T> Failure(string error)=>new Result<T> { IsSuccess=false,Error=error };
    }
}