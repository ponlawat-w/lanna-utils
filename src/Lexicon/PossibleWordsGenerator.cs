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

    public string[] Generate() => GenerateSegmented().Select(s => _segmentalLexicon.IdsToWord(s)).ToArray();

    private ulong[][] GenerateSegmented()
    {
        List<ulong[]> results = new List<ulong[]>();

        int i = 0;
        foreach (ulong[] segmentedWord in _segmentalLexicon.SegmentedWords)
        {
            if (++i % 100 == 0 && Report)
            {
                Console.WriteLine($"{i} from {_segmentalLexicon.SegmentedWords.Length}");
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

    private IEnumerable<ulong[]> GenerateSegmented(ulong[] word)
    {
        IEnumerable<WordRange> wordRangesInLexicon = WordRange.Generate(word.Length)
            .Where(w => _segmentalLexicon.Contains(w.SubIds(word)));

        List<ulong[]> results = WordRange.Reverse(wordRangesInLexicon, word.Length)
            .Select(wr => wr.SubIds(word).ToArray()).ToList();

        IEnumerable<ulong[]> wordsInLexicon = wordRangesInLexicon.Select(w => w.SubIds(word).ToArray());
        foreach (ulong[] separator in wordsInLexicon)
        {
            foreach (ulong[] subWord in SegmentalLexiconCollection.SplitIds(separator, word))
            {
                results.AddRange(GenerateSegmented(subWord));
            }
        }

        return results;
    }
}
