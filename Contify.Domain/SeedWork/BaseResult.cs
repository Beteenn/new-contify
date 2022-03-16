using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Contify.Domain.SeedWork
{
    public class BaseResult<T> : BaseResult where T : class
    {
        [JsonIgnore]
        public T Data { get; private set; }

        public BaseResult()
        {
            Data = null;
        }

        public BaseResult(T data)
        {
            Data = data;
        }

        public override BaseResult<T> AddErrorMessage(string message)
        {
            ErrorMessages.Add(message);
            return this;
        }

        public override BaseResult<T> AddErrorMessage(IEnumerable<string> message)
        {
            foreach (var item in message)
            {
                ErrorMessages.Add(item);
            }

            return this;
        }

        public BaseResult<T> AddData(T data)
        {
            Data = data;
            return this;
        }
    }

    public class BaseResult
    {
        public ICollection<string> ErrorMessages { get; private set; }

        [JsonIgnore]
        public bool Success => ErrorMessages.Count == 0;

        public BaseResult()
        {
            ErrorMessages = new List<string>();
        }

        public virtual BaseResult AddErrorMessage(string message)
        {
            ErrorMessages.Add(message);
            return this;
        }

        public virtual BaseResult AddErrorMessage(IEnumerable<string> message)
        {
            foreach (var item in message)
            {
                ErrorMessages.Add(item);
            }

            return this;
        }
    }
}
