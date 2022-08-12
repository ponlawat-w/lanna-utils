using LannaUtils.Lexicon.PossibleWordsUtils;

namespace LannaUtils.UnitTests;

public class TestWordRange
{
    [Fact]
    public void Generation()
    {
        WordRange[] results = WordRange.Generate(6);
        Assert.True(results.Length == 21);
    }

    [Fact]
    public void Substring()
    {
        string text = "ᨠᩥ᩠ᨶᨡᩮᩢ᩶ᩣ";
        Assert.Equal("ᨠᩥ᩠ᨶ", new WordRange(0, 4).Substring(text));
        Assert.Equal("ᨡᩮᩢ᩶ᩣ", new WordRange(4, 9).Substring(text));
    }

    [Fact]
    public void Reverse()
    {
        WordRange[] results;

        results = WordRange.Reverse(new WordRange[] {
            new WordRange(1, 3),
            new WordRange(3, 5)
        }, 5);
        Assert.True(results.Length == 1);
        Assert.Equal(0, results[0].FirstIndex);
        Assert.Equal(1, results[0].LastIndexExclusive);

        results = WordRange.Reverse(new WordRange[] {
            new WordRange(0, 2),
            new WordRange(3, 5)
        }, 5);
        Assert.True(results.Length == 1);
        Assert.Equal(2, results[0].FirstIndex);
        Assert.Equal(3, results[0].LastIndexExclusive);

        results = WordRange.Reverse(new WordRange[] {
            new WordRange(0, 3),
            new WordRange(1, 4)
        }, 5);
        Assert.True(results.Length == 1);
        Assert.Equal(4, results[0].FirstIndex);
        Assert.Equal(5, results[0].LastIndexExclusive);

        results = WordRange.Reverse(new WordRange[] {
            new WordRange(0, 3),
            new WordRange(1, 4),
            new WordRange(2, 5)
        }, 5);
        Assert.True(results.Length == 0);

        results = WordRange.Reverse(new WordRange[] {
            new WordRange(0, 2),
            new WordRange(4, 5)
        }, 5);
        Assert.True(results.Length == 1);
        Assert.Equal(2, results[0].FirstIndex);
        Assert.Equal(4, results[0].LastIndexExclusive);

        results = WordRange.Reverse(new WordRange[] {
            new WordRange(0, 3),
            new WordRange(5, 8)
        }, 8);
        Assert.True(results.Length == 1);
        Assert.Equal(3, results[0].FirstIndex);
        Assert.Equal(5, results[0].LastIndexExclusive);

        results = WordRange.Reverse(new WordRange[] {
            new WordRange(0, 2),
            new WordRange(3, 4),
            new WordRange(6, 8)
        }, 8);
        Assert.True(results.Length == 2);
        Assert.Equal(2, results[0].FirstIndex);
        Assert.Equal(3, results[0].LastIndexExclusive);
        Assert.Equal(4, results[1].FirstIndex);
        Assert.Equal(6, results[1].LastIndexExclusive);

        results = WordRange.Reverse(new WordRange[] {
            new WordRange(0, 2),
            new WordRange(4, 5),
            new WordRange(6, 8)
        }, 10);
        Assert.True(results.Length == 3);
        Assert.Equal(2, results[0].FirstIndex);
        Assert.Equal(4, results[0].LastIndexExclusive);
        Assert.Equal(5, results[1].FirstIndex);
        Assert.Equal(6, results[1].LastIndexExclusive);
        Assert.Equal(8, results[2].FirstIndex);
        Assert.Equal(10, results[2].LastIndexExclusive);
    }
}
