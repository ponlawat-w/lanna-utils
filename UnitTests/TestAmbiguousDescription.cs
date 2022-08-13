using CsvHelper;
using LannaUtils.Transforming;

namespace LannaUtils.UnitTests;

public class TestAmbiguousDescription
{
    TestAmbiguousDescriptionCase[] _testCases;

    public TestAmbiguousDescription()
    {
        using (StreamReader reader = new StreamReader("./TestCases/AmbiguousDescription.csv"))
        using (CsvReader csvReader = new CsvReader(reader, System.Globalization.CultureInfo.InvariantCulture))
        {
            _testCases = csvReader.GetRecords<TestAmbiguousDescriptionCase>().ToArray();
        }
    }

    [Fact]
    public void Test()
    {
        foreach (TestAmbiguousDescriptionCase testCase in _testCases)
        {
            Assert.Equal(testCase.Expected, AmbiguousDescription.Describe(testCase.Input));
        }
    }
}
