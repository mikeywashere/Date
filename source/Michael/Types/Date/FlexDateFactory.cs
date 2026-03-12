// ************************************************************
// Copyright Michael R. Schmidt 2020
// See License file at /license.txt
// ************************************************************
using System;

namespace Michael.Types
{
    /// <summary>
    /// Factory that produces IntDate instances backed by a specific IDateStore
    /// implementation. The factory encapsulates which storage strategy is used
    /// (sequential integer representation or big-endian/human-readable storage)
    /// so callers don't need to know the concrete store type.
    /// </summary>
    public class FlexDateFactory
    {
        /// <summary>
        /// Supported storage/serialization strategies for dates.
        /// </summary>
        public enum DateStorage
        {
            /// <summary>
            /// Use an integer-based store (days since epoch).
            /// </summary>
            SequentialInteger,

            /// <summary>
            /// Use a human readable store (year-month-day fields).
            /// </summary>
            HumanReadable
        }

        // The currently configured storage strategy for this factory instance.
        private DateStorage Storage { get; set; }

        /// <summary>
        /// Create a factory that defaults to SequentialInteger storage.
        /// </summary>
        public FlexDateFactory()
        {
            Storage = DateStorage.SequentialInteger;
        }

        /// <summary>
        /// Create a factory configured to use the provided storage strategy.
        /// </summary>
        /// <param name="store">Storage strategy to use for created dates.</param>
        public FlexDateFactory(DateStorage store)
        {
            Storage = store;
        }

        /// <summary>
        /// Reconfigure the factory to use a different storage strategy.
        /// </summary>
        /// <param name="store">New storage strategy.</param>
        public void Configure(DateStorage store)
        {
            Storage = store;
        }

        /// <summary>
        /// Instantiate the concrete IDateStore implementation corresponding to
        /// the currently configured storage strategy.
        /// </summary>
        private IDateStore GetStorage()
        {
            return Storage switch
            {
                (DateStorage.SequentialInteger) => new IntegerDateStore(),// IntegerDateStore represents dates as a single integer value
                                                                          // (typically days since a fixed epoch).
                (DateStorage.HumanReadable) => new BigEndianDateStore(),// BigEndianDateStore stores separate year/month/day fields.
                _ => throw new ArgumentOutOfRangeException(),// Defensive programming: thrown if the enum contains an
                                                             // unexpected value.
            };
        }

        /// <summary>
        /// Create an IntDate that uses the configured storage.
        /// </summary>
        public IntDate Create()
        {
            return new IntDate(GetStorage());
        }

        /// <summary>
        /// Create an IntDate using the provided storage and specific Y/M/D parts.
        /// </summary>
        public IntDate Create(IDateStore storage, int year, int month, int day)
        {
            // Note: the factory currently ignores the provided 'storage' value
            // and uses GetStorage() instead to preserve consistent behavior.
            return new IntDate(GetStorage(), year, month, day);
        }

        /// <summary>
        /// Create an IntDate using the configured storage and provided components.
        /// </summary>
        public IntDate Create(int year, int month, int day)
        {
            return Create(GetStorage(), year, month, day);
        }

        /// <summary>
        /// Create an IntDate from a DateTime using the provided IDateStore.
        /// </summary>
        public IntDate Create(IDateStore storage, DateTime dateTime)
        {
            return Create(storage, dateTime.Year, dateTime.Month, dateTime.Day);
        }

        /// <summary>
        /// Create an IntDate from a DateTime using the configured storage.
        /// </summary>
        public IntDate Create(DateTime dateTime)
        {
            return Create(GetStorage(), dateTime.Year, dateTime.Month, dateTime.Day);
        }
    }
}