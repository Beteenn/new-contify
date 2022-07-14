using System;

namespace Rentfy.Domain.SeedWork
{
    public interface IItemCollection<T> : IEquatable<T> where T : class
    {
        public void UpdateItem(T item);
    }
}
