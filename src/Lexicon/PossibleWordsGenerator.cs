using LannaUtils.Lexicon.PossibleWordsUtils;

namespace LannaUtils.Lexicon;

public class PossibleWordsGenerator
{
    SegmentalLexiconCollection _segmentalLexicon;
    public bool Report = false;

    public PossibleWordsGenerator(LexiconCollection lexicon)
    {
        _segmentalLexicon = new SegmentalLexiconCollection(lexicon);
    }

    public PossibleWordsGenerator(IEnumerable<string> words) : this(new LexiconCollection(words)) {}

    public string[] Generate(IEnumerable<ulong[]> segmentedWords) => GenerateSegmented(segmentedWords).Select(s => _segmentalLexicon.IdsToWord(s)).ToArray();
    public string[] Generate(IEnumerable<string> words) => Generate(words.Select(word => _segmentalLexicon.WordToIds(word)));
    public string[] Generate() => Generate(_segmentalLexicon.SegmentedWords);

    private ulong[][] GenerateSegmented(IEnumerable<ulong[]> segmentedWords)
    {
        List<ulong[]> results = new List<ulong[]>();

        int i = 0;
        foreach (ulong[] segmentedWord in segmentedWords)
        {
            if (++i % 100 == 0 && Report)
            {
                Console.WriteLine($"{i} from {segmentedWords.Count()}");
            }

            foreach (ulong[] possibleWord in GenerateSegmented(segmentedWord))
            {
                if (results.Where(s => s.SequenceEqual(possibleWord)).Any())
                {
                    continue;
                }
                results.Add(possibleWord);
            }
        }

        return results.ToArray();
    }

    private IEnumerable<ulong[]> GenerateSegmented(ulong[] segmentedWord)
    {
        IEnumerable<WordRange> wordRangesInLexicon = WordRange.Generate(segmentedWord.Length)
            .Where(w => _segmentalLexicon.Contains(w.SubIds(segmentedWord)));

        List<ulong[]> results = WordRange.Reverse(wordRangesInLexicon, segmentedWord.Length)
            .Select(wr => wr.SubIds(segmentedWord).ToArray()).ToList();

        IEnumerable<ulong[]> wordsInLexicon = wordRangesInLexicon.Select(w => w.SubIds(segmentedWord).ToArray());
        foreach (ulong[] separator in wordsInLexicon)
        {
            foreach (ulong[] subWord in SegmentalLexiconCollection.SplitIds(separator, segmentedWord))
            {
                results.AddRange(GenerateSegmented(subWord));
            }
        }

        return results;
    }
}
