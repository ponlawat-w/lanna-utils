namespace LannaUtils.UnitTests;

using CsvHelper.Configuration.Attributes;

public class TestSegmentExplanationCase
{
    [Name("input")]
    public string Input { get; set; } = "";

    [Name("central")]
    public string Central { get; set; } = "";

    [Name("centralLeft")]
    public string CentralLeft { get; set; } = "";

    [Name("left")]
    public string Left { get; set; } = "";

    [Name("top")]
    public string Top { get; set; } = "";

    [Name("right")]
    public string Right { get; set; } = "";

    [Name("rightTop")]
    public string RightTop { get; set; } = "";

    [Name("rightBottom")]
    public string RightBottom { get; set; } = "";

    [Name("bottom")]
    public string Bottom { get; set; } = "";
}
