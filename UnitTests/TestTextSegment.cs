using CsvHelper;
using LannaUtils.Segmenting;

namespace LannaUtils.UnitTests;

public class TestTextSegment
{
    TestTextSegmentCase[] _testCases;

    public TestTextSegment()
    {
        using (StreamReader reader = new StreamReader("./TestCases/TextSegment.csv"))
        using (CsvReader csvReader = new CsvReader(reader, System.Globalization.CultureInfo.InvariantCulture))
        {
            _testCases = csvReader.GetRecords<TestTextSegmentCase>().ToArray();
        }
    }

    [Fact]
    public void Test()
    {
        foreach (TestTextSegmentCase testCase in _testCases)
        {
            Assert.Equal(testCase.ExpectedSegments, TextSegment.Split(testCase.Input));
        }
    }
}
