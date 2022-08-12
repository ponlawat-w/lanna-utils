using LannaUtils.Lexicon.PossibleWordsUtils;

namespace LannaUtils.Lexicon;

public class SegmentalLexiconCollection
{
    public IDictionary<ulong, string> SegmentValuesDict;
    public IDictionary<string, ulong> SegmentIdsDict;
    public ulong[][] SegmentedWords;
    private ulong lastId = 0;

    public SegmentalLexiconCollection(IEnumerable<string> words)
    {
        SegmentValuesDict = new Dictionary<ulong, string>();
        SegmentIdsDict = new Dictionary<string, ulong>();
        
        List<ulong[]> segmentedWords = new List<ulong[]>();
        foreach (string word in words)
        {
            segmentedWords.Add(WordToIds(word));
        }

        SegmentedWords = segmentedWords.ToArray();
    }

    public ulong[] WordToIds(string word) => LannaUtils.Segmenting.TextSegment.Split(word)
        .Select(segment => SegmentToId(segment))
        .ToArray();

    public string IdsToWord(IEnumerable<ulong> segmentIds) => string.Join("", segmentIds.Select(segmentId => SegmentValuesDict[segmentId]));

    public LexiconCollection ToLexicon() => new LexiconCollection(SegmentedWords.Select(ids => IdsToWord(ids)));

    public bool Contains(IEnumerable<ulong> test)
    {
        foreach (ulong[] segmentedWord in SegmentedWords)
        {
            if (segmentedWord.SequenceEqual(test))
            {
                return true;
            }
        }
        return false;
    }

    private ulong SegmentToId(string segment)
    {
        if (SegmentIdsDict.ContainsKey(segment))
        {
            return SegmentIdsDict[segment];
        }

        ulong newId = ++lastId;
        SegmentValuesDict[newId] = segment;
        SegmentIdsDict[segment] = newId;

        return newId;
    }

    public static ulong[][] SplitIds(ulong[] separator, ulong[] text)
    {
        IEnumerable<WordRange> separatorWordRanges = WordRange.Generate(text.Length)
            .Where(w => w.SubIds(text).SequenceEqual(separator));
        
        return WordRange.Reverse(separatorWordRanges, text.Length)
            .Select(w => w.SubIds(text).ToArray()).ToArray();
    }
}
