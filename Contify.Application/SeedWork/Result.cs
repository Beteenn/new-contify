using Contify.Domain.SeedWork;

namespace Contify.Application.SeedWork
{
    public sealed class Result : BaseResult
    {
        public Result() : base() { }
    }

    public sealed class Result<T> : BaseResult<T> where T : class
    {
        public Result(T data) : base(data) { }
    }
}
