using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Rentfy.Domain.SeedWork
{
    public abstract class AEnumeration<TEnum> : AEnumeration
            where TEnum : AEnumeration
    {
        protected AEnumeration(int id, string name) : base(id, name) { }

        public static IEnumerable<TEnum> GetAll()
            => GetEnumerations<TEnum>();

        public static TEnum FromName(string name)
            => GetEnumerations<TEnum>().FirstOrDefault(e => e.Name.ToLower() == name.ToLower());

        public static TEnum FromId(int id)
            => GetEnumerations<TEnum>().FirstOrDefault(e => e.Id == id);
    }

    public abstract class AEnumeration : IComparable
    {
        public int Id { get; set; }
        public string Name { get; set; }

        protected AEnumeration(int id, string name)
        {
            Id = id;
            Name = name;
        }

        protected static IEnumerable<T> GetEnumerations<T>()
            where T : AEnumeration
        {
            var fields = typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
                .Where(x => !x.IsLiteral);
            return fields.Select(f => f.GetValue(null)).Cast<T>();
        }

        public override bool Equals(object otherObj)
        {
            var otherValue = otherObj as AEnumeration;

            if (otherValue == null) return false;

            var typeMatches = GetType().Equals(otherObj.GetType());
            var valueMatches = Id.Equals(otherValue.Id);

            return typeMatches && valueMatches;
        }

        public override int GetHashCode() => Id.GetHashCode();

        public override string ToString() => Name;

        public int CompareTo(object otherObj) => Id.CompareTo(((AEnumeration)otherObj).Id);

    }
}
