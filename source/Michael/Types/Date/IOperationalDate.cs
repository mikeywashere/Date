// ************************************************************
// Copyright Michael R. Schmidt 2020
// See License file at /license.txt
// ************************************************************
using System.Collections.Generic;

namespace Michael.Types
{
    /// <summary>
    /// Represents a date value that supports basic arithmetic and range
    /// generation operations. This interface extends <see cref="IIntDate"/>
    /// to include behavior for adding/subtracting days and producing a
    /// sequence of operational dates between two points.
    /// </summary>
    public interface IOperationalDate : IIntDate
    {
        /// <summary>
        /// Returns a new <see cref="IntDate"/> that is the specified number
        /// of days after the current date. The original instance is not
        /// modified — this method produces a new value.
        /// </summary>
        /// <param name="days">Number of days to add (may be negative).</param>
        IntDate AddDays(int days);

        /// <summary>
        /// Returns a new <see cref="IntDate"/> that is the specified number
        /// of days before the current date.
        /// </summary>
        /// <param name="days">Number of days to subtract (may be negative).</param>
        IntDate SubtractDays(int days);

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
        IEnumerable<IOperationalDate> Range(IIntDate startDate, IIntDate endDate);
    }
}
