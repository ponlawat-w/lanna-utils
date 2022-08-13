using CsvHelper.Configuration.Attributes;

namespace LannaUtils.UnitTests;

public class TestPossibleWordsCase
{
    [Name("lexicon")]
    public string LexiconWordsRaw { get; set; } = "";
    [Ignore]
    public string[] LexiconWords { get => LexiconWordsRaw.Split('/').Select(x => x.Trim()).Where(x => x != "").ToArray(); }

    [Name("input")]
    public string InputsRaw { get; set; } = "";
    [Ignore]
    public string[] Inputs { get => InputsRaw.Split('/').Select(x => x.Trim()).Where(x => x != "").ToArray(); }

    [Name("outputs")]
    public string LexiconOutputsRaw { get; set; } = "";
    [Ignore]
    public string[] LexiconOutputs { get => LexiconOutputsRaw.Split('/').Select(x => x.Trim()).Where(x => x != "").OrderBy(x => x).ToArray(); }
}
