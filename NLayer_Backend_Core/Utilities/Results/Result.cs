namespace NLayer_Backend_Core.Utilities.Results
{
    public class Result : IResult
    {
        //:this(success) demek aşagıdaki constructoruda tetikle demektir.
        public Result(bool success, string message) : this(success)
        {
            Message = message;
        }
        public Result(bool success)
        {
            Success = success;
        }
        public bool Success { get; }

        public string Message { get; }
    }
}
