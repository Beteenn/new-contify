using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Rentfy.Application.SeedWork
{
    public class Result
    {
        public ICollection<string> ErrorMessages { get; private set; }

        [JsonIgnore]
        public bool Success => ErrorMessages.Count == 0;

        public Result()
        {
            ErrorMessages = new List<string>();
        }

        public virtual Result AddErrorMessage(string message)
        {
            ErrorMessages.Add(message);
            return this;
        }

        public virtual Result AddErrorMessage(IEnumerable<string> message)
        {
            foreach (var item in message)
            {
                ErrorMessages.Add(item);
            }

            return this;
        }
    }

    public sealed class Result<T> : Result where T : class
    {
        [JsonIgnore]
        public T Data { get; private set; }

        public Result() { }

        public Result(T data)
        {
            Data = data;
        }

        public override Result<T> AddErrorMessage(string message)
        {
            ErrorMessages.Add(message);
            return this;
        }

        public override Result<T> AddErrorMessage(IEnumerable<string> message)
        {
            foreach (var item in message)
            {
                ErrorMessages.Add(item);
            }

            return this;
        }

        public Result<T> AddData(T data)
        {
            Data = data;
            return this;
        }
    }
}
