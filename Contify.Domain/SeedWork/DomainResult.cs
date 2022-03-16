namespace Contify.Domain.SeedWork
{
    public sealed class DomainResult : BaseResult
    {
        public DomainResult() : base() { }
    }

    public sealed class DomainResult<T> : BaseResult<T> where T : class
    {

        public DomainResult() : base() { }
        public DomainResult(T data) : base(data) { }
    }
}
