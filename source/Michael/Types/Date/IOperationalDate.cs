// ************************************************************
// Copyright Michael R. Schmidt 2020
// See License file at /license.txt
// ************************************************************

namespace Michael.Types
{
    /// <summary>
    /// Represents a date value that supports basic arithmetic and range
    /// generation operations. This interface extends <see cref="ISimpleDate"/>
    /// to include behavior for adding/subtracting days and producing a
    /// sequence of operational dates between two points.
    /// </summary>
    public interface IOperationalDate : ISimpleDate
    {
        /// <summary>
        /// Returns a new <see cref="SequentialIntegerDate"/> that is the specified number
        /// of days after the current date. The original instance is not
        /// modified — this method produces a new value.
        /// </summary>
        /// <param name="days">Number of days to add (may be negative).</param>
        SequentialIntegerDate AddDays(int days);

        /// <summary>
        /// Returns a new <see cref="SequentialIntegerDate"/> that is the specified number
        /// of days before the current date.
        /// </summary>
        /// <param name="days">Number of days to subtract (may be negative).</param>
        SequentialIntegerDate SubtractDays(int days);

        /// <summary>
        /// Produces an enumerable sequence of <see cref="IOperationalDate"/>
        /// values starting at <paramref name="startDate"/> (inclusive) and
        /// iterating forward until reaching <paramref name="endDate"/>
        /// (exclusive). The sequence is generated lazily and can be used in
        /// foreach statements or LINQ queries.
        /// </summary>
        /// <param name="startDate">The first date in the range.</param>
        /// <param name="endDate">The exclusive end marker for the range.</param>
        /// <returns>An enumerable of operational dates from start (inclusive)
        /// to end (exclusive).</returns>
        IEnumerable<IOperationalDate> Range(ISimpleDate startDate, ISimpleDate endDate);
    }
}
