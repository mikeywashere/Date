using Michael.Types;

namespace GeneralUnitTests;

// Unit tests for FlexDate range enumeration behavior.
//
// These tests exercise RangeTo(...) for different DateStorage strategies
// to ensure the returned enumerables iterate the expected number of days.
// Note: the methods below perform enumeration and counting but do not
// contain assertions; they act as smoke/integration checks and can be
// expanded with asserts as needed.
public class UnitTest1
{
    // Test the RangeTo enumeration when the factory uses a human-readable
    // internal storage representation. The test creates a fixed historical
    // start date and an end date of "now", then iterates the range and
    // counts elements to validate enumeration works end-to-end.
    [Fact]
    public void Test_HumanReadable()
    {
        // Create a FlexDateFactory configured to use a human-readable storage
        // representation (for example: separate year/month/day fields).
        FlexDateFactory factory = new FlexDateFactory(FlexDateFactory.DateStorage.HumanReadable);

        // Create the start date (1965-11-01) and an end date representing the
        // current moment. These are FlexDate objects, not System.DateTime.
        var startDate = factory.Create(1965, 11, 1);
        var endDate = factory.Create(DateTime.Now);

        // Iterate the range returned by RangeTo and count each day. The loop
        // ensures the enumerable can be iterated without throwing and yields
        // one item per day in the interval.
        var count = 0;
        var range = startDate.RangeTo(endDate);
        foreach (var day in range)
        {
            count++;
        }
    }

    // Test the RangeTo enumeration when the factory uses a sequential
    // integer internal storage representation. This verifies enumeration
    // logic is independent of the underlying storage format.
    [Fact]
    public void Test_SequentialInteger()
    {
        // Create a FlexDateFactory configured to use a sequential integer
        // storage representation (for example: days since an epoch).
        FlexDateFactory factory = new FlexDateFactory(FlexDateFactory.DateStorage.SequentialInteger);

        // Same start/end pair as above; iterate the range and count items.
        var startDate = factory.Create(1965, 11, 1);
        var endDate = factory.Create(DateTime.Now);

        var count = 0;
        var range = startDate.RangeTo(endDate);
        foreach (var day in range)
        {
            count++;
        }
    }

}
