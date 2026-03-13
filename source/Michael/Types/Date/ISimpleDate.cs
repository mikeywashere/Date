// ************************************************************
// Copyright Michael R. Schmidt 2020
// See License file at /license.txt
// ************************************************************

namespace Michael.Types
{
    public interface ISimpleDate
    {
        /// <summary>
        /// Represents a date as integer components (year, month, day).
        /// Implementations are expected to provide read-only access to the
        /// individual date parts.
        /// </summary>
        int Day { get; }

        /// <summary>
        /// The month component of the date (1-12).
        /// </summary>
        int Month { get; }

        /// <summary>
        /// The year component of the date (e.g. 1965).
        /// </summary>
        int Year { get; }
    }
}