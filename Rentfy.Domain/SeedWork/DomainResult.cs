using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Rentfy.Domain.SeedWork
{
    public class DomainResult
    {

        public ICollection<string> ErrorMessages { get; private set; }

        [JsonIgnore]
        public bool Success => ErrorMessages.Count == 0;

        public DomainResult()
        {
            ErrorMessages = new List<string>();
        }

        public virtual DomainResult AddErrorMessage(string message)
        {
            ErrorMessages.Add(message);
            return this;
        }

        public virtual DomainResult AddErrorMessage(IEnumerable<string> message)
        {
            foreach (var item in message)
            {
                ErrorMessages.Add(item);
            }

            return this;
        }
    }

    public sealed class DomainResult<T> : DomainResult where T : class
    {
        [JsonIgnore]
        public T Data { get; private set; }

        public DomainResult()
        {
            Data = null;
        }

        public DomainResult(T data)
        {
            Data = data;
        }

        public override DomainResult<T> AddErrorMessage(string message)
        {
            ErrorMessages.Add(message);
            return this;
        }

        public override DomainResult<T> AddErrorMessage(IEnumerable<string> message)
        {
            foreach (var item in message)
            {
                ErrorMessages.Add(item);
            }

            return this;
        }

        public DomainResult<T> AddData(T data)
        {
            Data = data;
            return this;
        }
    }
}
