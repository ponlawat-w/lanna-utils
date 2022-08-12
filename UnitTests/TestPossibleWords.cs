using CsvHelper;
using LannaUtils.Lexicon;

namespace LannaUtils.UnitTests;

public class TestPossibleWords
{
    TestPossibleWordsCase[] _testCases;

    public TestPossibleWords()
    {
        using (StreamReader reader = new StreamReader("./TestCases/PossibleWords.csv"))
        using (CsvReader csvReader = new CsvReader(reader, System.Globalization.CultureInfo.InvariantCulture))
        {
            _testCases = csvReader.GetRecords<TestPossibleWordsCase>().ToArray();
        }
    }

    [Fact]
    public void Test()
    {
        foreach (TestPossibleWordsCase testCase in _testCases)
        {
            PossibleWordsGenerator wordsGenerator = new PossibleWordsGenerator(testCase.LexiconWords);
            Assert.Equal(
                testCase.LexiconOutputs,
                wordsGenerator.Generate().OrderBy(s => s).ToArray()
            );
        }
    }
}
