namespace LannaUtils.Lexicon.PossibleWordsUtils;

public class WordRange
{
    public int FirstIndex;
    public int LastIndexExclusive;

    public WordRange(int firstIndex, int lastIndexExclusive)
    {
        FirstIndex = firstIndex;
        LastIndexExclusive = lastIndexExclusive;
    }

    public string Substring(string str) => str.Substring(FirstIndex, LastIndexExclusive - FirstIndex);

    public IEnumerable<ulong> SubIds(IEnumerable<ulong> ids) => ids.Skip(FirstIndex).Take(LastIndexExclusive - FirstIndex);

    public bool Contains(int index) => index >= FirstIndex && index < LastIndexExclusive;

    public static WordRange[] Generate(int strLength)
    {
        List<WordRange> results = new List<WordRange>();
        for (int i = 0; i < strLength; i++)
        for (int j = i + 1; j < strLength + 1; j++)
        {
            results.Add(new WordRange(i, j));
        }
        return results.ToArray();
    }

    public static WordRange[] Reverse(IEnumerable<WordRange> wordRanges, int length)
    {
        int[] outIndices = Enumerable.Range(0, length)
            .Where(i => !wordRanges.Where(w => w.Contains(i)).Any()).ToArray();

        List<List<int>> groups = new List<List<int>>();
        int? previousOutIndex = null;
        List<int> currentGroup = new List<int>();
        foreach (int outIndex in outIndices)
        {
            if (previousOutIndex == null || outIndex - previousOutIndex == 1)
            {
                currentGroup.Add(outIndex);
                previousOutIndex = outIndex;
                continue;
            }
            
            groups.Add(currentGroup);
            currentGroup = new List<int>();
            currentGroup.Add(outIndex);
            previousOutIndex = outIndex;
        }
        if (currentGroup.Count > 0)
        {
            groups.Add(currentGroup);
        }

        return groups.Select(group => new WordRange(group.First(), group.Last() + 1)).ToArray();
    }
}
