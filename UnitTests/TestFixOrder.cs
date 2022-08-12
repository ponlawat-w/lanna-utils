using CsvHelper;
using LannaUtils.Cleaning;

namespace LannaUtils.UnitTests;

public class TestFixOrder
{
    TestFixOrderCase[] _testCases;

    public TestFixOrder()
    {
        using (StreamReader reader = new StreamReader("./TestCases/FixOrder.csv"))
        using (CsvReader csvReader = new CsvReader(reader, System.Globalization.CultureInfo.InvariantCulture))
        {
            _testCases = csvReader.GetRecords<TestFixOrderCase>().ToArray();
        }
    }

    [Fact]
    public void Test()
    {
        foreach (TestFixOrderCase testCase in _testCases)
        {
            Assert.Equal(testCase.Expected, FixOrder.Fix(testCase.Input));
        }
    }
}