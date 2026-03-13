// ************************************************************
// Copyright Michael R. Schmidt 2020
// See License file at /license.txt
// ************************************************************

namespace Michael.Types
{
    /// <summary>
    /// Generic interface that represents a storage implementation for a date.
    /// The generic parameter <typeparamref name="T"/> exposes the underlying
    /// raw representation type (for example <c>int</c> for packed YYYYMMDD or
    /// other types for different stores).
    /// </summary>
    /// <remarks>
    /// The generic parameter is declared covariant (<c>out T</c>) to allow
    /// consumers to treat more specific store implementations as their
    /// base interface. The interface exposes the date as both a high-level
    /// IIntDate and as the raw underlying value.
    /// </remarks>
    public interface IDateStore<out T>
    {
        /// <summary>
        /// Gets or sets the date as integer components (year, month, day).
        /// Implementations map this property to their internal representation.
        /// </summary>
        ISimpleDate SimpleDate { get; set; }

        /// <summary>
        /// The raw underlying storage value for the date. The concrete type
        /// is provided by the generic parameter <typeparamref name="T"/>.
        /// </summary>
        T Raw { get; }

        /// <summary>
        /// Converts the packed integer to a <see cref="DateOnly"/> instance.
        /// </summary>
        /// <returns>A DateOnly representing the stored date.</returns>
        public DateOnly ToDateOnly();

        /// <summary>
        /// Converts the packed integer to a <see cref="DateTime"/> at midnight.
        /// </summary>
        /// <returns>A DateTime representing the stored date at 00:00:00.</returns>
        public DateTime ToDateTime();

        /// <summary>
        /// Converts the packed integer to a <see cref="DateTime"/> using the
        /// supplied <see cref="TimeOnly"/> for the time component.
        /// </summary>
        /// <param name="time">TimeOfDay to combine with the stored date.</param>
        /// <returns>A DateTime representing the stored date with the provided time.</returns>
        public DateTime ToDateTime(TimeOnly time);
    }

    /// <summary>
    /// Non-generic version of <see cref="IDateStore{T}"/> that exposes the
    /// raw storage value as an object. Useful when the concrete raw type is
    /// not known or not important to the caller.
    /// </summary>
    public interface IDateStore
    {
        /// <summary>
        /// Gets or sets the date as integer components (year, month, day).
        /// </summary>
        ISimpleDate SimpleDate { get; set; }

        /// <summary>
        /// The raw underlying storage value boxed as an object.
        /// </summary>
        object Raw { get; }
    }
}