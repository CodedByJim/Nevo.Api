using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Nevo.Data
{
    /// <summary>
    ///     List that can be equated.
    /// </summary>
    /// <typeparam name="T">Element type of the list.</typeparam>
    public class EquatableList<T> : IList<T>, IEquatable<EquatableList<T>>
        where T : IEquatable<T>
    {
        /// <summary>
        ///     Inner list.
        /// </summary>
        protected readonly IList<T> _listImplementation;

        /// <summary>
        ///     Create a new <see cref="EquatableList{T}" />.
        /// </summary>
        public EquatableList() : this(new List<T>())
        {
        }

        /// <summary>
        ///     Create a new <see cref="EquatableList{T}" /> having an initial underlying collection.
        /// </summary>
        /// <param name="listImplementation">The implementation of the underlying list.</param>
        /// <exception cref="ArgumentNullException">When <paramref name="listImplementation"/> is null.</exception>
        protected EquatableList(IList<T> listImplementation)
        {
            if (listImplementation == null)
                throw new ArgumentNullException(nameof(listImplementation));
            _listImplementation = listImplementation;
        }

        /// <inheritdoc />
        public bool Equals(EquatableList<T>? other)
        {
            if (other == null) return false;
            if (other.Count != Count) return false;
            for (var index = 0; index < Count; index++)
                if (!this[index].Equals(other[index]))
                    return false;
            return true;
        }

        /// <inheritdoc />
        public IEnumerator<T> GetEnumerator() => _listImplementation.GetEnumerator();

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)_listImplementation).GetEnumerator();

        /// <inheritdoc />
        public void Add(T item) => _listImplementation.Add(item);

        /// <inheritdoc />
        public void Clear() => _listImplementation.Clear();

        /// <inheritdoc />
        public bool Contains(T item) => _listImplementation.Contains(item);

        /// <inheritdoc />
        public void CopyTo(T[] array, int arrayIndex) => _listImplementation.CopyTo(array, arrayIndex);

        /// <inheritdoc />
        public bool Remove(T item) => _listImplementation.Remove(item);

        /// <inheritdoc />
        public int Count => _listImplementation.Count;

        /// <inheritdoc />
        public bool IsReadOnly => _listImplementation.IsReadOnly;

        /// <inheritdoc />
        public int IndexOf(T item) => _listImplementation.IndexOf(item);

        /// <inheritdoc />
        public void Insert(int index, T item) => _listImplementation.Insert(index, item);

        /// <inheritdoc />
        public void RemoveAt(int index) => _listImplementation.RemoveAt(index);

        /// <inheritdoc />
        public T this[int index]
        {
            get => _listImplementation[index];
            set => _listImplementation[index] = value;
        }

        /// <summary>
        ///     Implicit cast used to quickly convert a List.
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>A wrapped value</returns>
        public static implicit operator EquatableList<T>(List<T>? value) => new(value ?? new());

        /// <summary>
        ///     Implicit cast used to quickly convert an array.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>A wrapped value.</returns>
        public static implicit operator EquatableList<T>(T[]? value) => new(value ?? Array.Empty<T>());

        /// <summary>
        ///     Implicit cast used to quickly unwrap the value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>A wrapped value.</returns>
        public static implicit operator List<T>?(EquatableList<T>? value) => value?._listImplementation.ToList();

        /// <summary>
        ///     Equals operator.
        /// </summary>
        /// <param name="obj1">The first object.</param>
        /// <param name="obj2">The second object.</param>
        /// <returns>True when equal</returns>
        public static bool operator ==(EquatableList<T>? obj1, EquatableList<T>? obj2) => Equals(obj1, obj2);

        /// <summary>
        ///     Not equals operator.
        /// </summary>
        /// <param name="obj1">The first object.</param>
        /// <param name="obj2">The second object.</param>
        /// <returns>True when not equal.</returns>
        public static bool operator !=(EquatableList<T> obj1, EquatableList<T> obj2) => !(obj1 == obj2);

        /// <inheritdoc />
        public override bool Equals(object? obj)
            => Equals(obj as EquatableList<T>);

        /// <inheritdoc />
        public override int GetHashCode()
        {
            unchecked
            {
                var result = 0x2AAAAAAA;
                foreach (var equatable in _listImplementation)
                    result = (result * 0x155) ^ equatable.GetHashCode();
                return result;
            }
        }
    }
}