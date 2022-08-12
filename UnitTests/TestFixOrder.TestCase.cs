using CsvHelper.Configuration.Attributes;

namespace LannaUtils.UnitTests;

public class TestFixOrderCase
{
    [Name("input")]
    public string Input { get; set; } = "";

    [Name("expected")]
    public string Expected { get; set; } = "";
}
