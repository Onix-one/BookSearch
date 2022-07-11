namespace BookSearch.Common.Systems
{
    public class Result
    {
        public bool Succeeded { get; private set; }
        public static Result Success { get; } = new() { Succeeded = true };
        public static Result Failed()
        {
            var result = new Result { Succeeded = false };
            return result;
        }
    }
}
