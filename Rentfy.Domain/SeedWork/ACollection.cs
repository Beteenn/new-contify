using System;
using System.Collections.Generic;
using System.Linq;

namespace Rentfy.Domain.SeedWork
{
    public abstract class ACollection<T> : List<T> where T : class, IItemCollection<T>
    {
        protected T ExistintItem(T item) => this.FirstOrDefault(x => x.Equals(item));

        public void AddItem(T item)
        {
            if (item == null) return;

            this.Add(item);
        }

        public void AddItems(IEnumerable<T> items)
        {
            if (items == null || items.Any()) return;

            this.AddRange(items);
        }

        public void UpdateItem(T item)
        {
            if (item == null) return;

            var itemExistente = ExistintItem(item);

            if (itemExistente == null) return;

            itemExistente.UpdateItem(item);
        }

        public void RemoveItem(T item)
        {
            this.Remove(item);
        }

        public void RemoveItem(IEnumerable<T> items)
        {
            this.RemoveAll(x => items.Contains(x));
        }
    }
}
