using CsvHelper;
using LannaUtils.Segmenting;

namespace LannaUtils.UnitTests;

public class TestSegmentExplanation
{
    TestSegmentExplanationCase[] _testCases;

    public TestSegmentExplanation()
    {
        using (StreamReader reader = new StreamReader("./TestCases/SegmentExplanation.csv"))
        using (CsvReader csvReader = new CsvReader(reader, System.Globalization.CultureInfo.InvariantCulture))
        {
            _testCases = csvReader.GetRecords<TestSegmentExplanationCase>().ToArray();
        }
    }

    [Fact]
    public void TestFail()
    {
        SegmentExplanation segmentExplanation;

        segmentExplanation = new SegmentExplanation();
        Assert.False(segmentExplanation.Valid);

        segmentExplanation = new SegmentExplanation("ᨶᩦ᩵ᨸᩮ᩠ᨶᨡᩬᩴ᩶ᨤ᩠ᩅᩣ᩠ᨾᨴᩦ᩵ᨿᩣ᩠ᩅ᩻");
        Assert.False(segmentExplanation.Valid);
    }

    [Fact]
    public void Test()
    {
        foreach (TestSegmentExplanationCase testCase in _testCases)
        {
            SegmentExplanation segmentExplanation = new SegmentExplanation(testCase.Input);
            Assert.True(segmentExplanation.Valid, testCase.Input);

            Assert.True(testCase.Central == segmentExplanation.Central,
                $"{testCase.Input} Central (expected {testCase.Central} actual {segmentExplanation.Central})");
            Assert.True(testCase.CentralLeft == segmentExplanation.CentralLeft,
                $"{testCase.Input} CentralLeft (expected {testCase.CentralLeft} actual {segmentExplanation.CentralLeft})");
            Assert.True(testCase.Left == segmentExplanation.Left,
                $"{testCase.Input} Left (expected {testCase.Left} actual {segmentExplanation.Left})");
            Assert.True(testCase.Top == segmentExplanation.Top,
                $"{testCase.Input} Top (expected {testCase.Top} actual {segmentExplanation.Top})");
            Assert.True(testCase.Right == segmentExplanation.Right,
                $"{testCase.Input} Right (expected {testCase.Right} actual {segmentExplanation.Right})");
            Assert.True(testCase.RightTop == segmentExplanation.RightTop,
                $"{testCase.Input} RightTop (expected {testCase.RightTop} actual {segmentExplanation.RightTop})");
            Assert.True(testCase.RightBottom == segmentExplanation.RightBottom,
                $"{testCase.Input} RightBottom (expected {testCase.RightBottom} actual {segmentExplanation.RightBottom})");
            Assert.True(testCase.Bottom == segmentExplanation.Bottom,
                $"{testCase.Input} Bottom (expected {testCase.Bottom} actual {segmentExplanation.Bottom})");
        }
    }
}
