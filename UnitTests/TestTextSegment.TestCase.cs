using CsvHelper.Configuration.Attributes;

namespace LannaUtils.UnitTests;

public class TestTextSegmentCase
{
    [Name("input")]
    public string Input { get; set; } = "";

    [Name("expected")]
    public string Expected { get; set; } = "";

    [Ignore]
    public string[] ExpectedSegments
    {
        get => Expected.Split('/').ToArray();
    }
}
