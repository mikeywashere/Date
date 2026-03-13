# Date

## A library for storing dates as integers

### Example

FlexDateFactory factory = new FlexDateFactory(FlexDateFactory.DateStorage.SequentialInteger);

// Same start/end pair as above; iterate the range and count items.
var startDate = factory.Create(1965, 11, 1);
var endDate = factory.Create(DateTime.Now);

var count = 0;
var current = startDate;
while (true)
{
    // the test
    var thisDate = startDate.AddDays(count);
    Assert.Equal(thisDate.Day, current.Day); // Optional: verify each day matches expected value
    Assert.Equal(thisDate.Month, current.Month); // Optional: verify each day matches expected value
    Assert.Equal(thisDate.Year, current.Year); // Optional: verify each day matches expected value

    // do we exit
    if (current.Day == endDate.Day && current.Month == endDate.Month && current.Year == endDate.Year)
        break;

    // add a day and continue
    current = current.AddDays(1);
    count++;
}