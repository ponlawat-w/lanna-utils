using System.Collections;

namespace LannaUtils.Lexicon;

public class LexiconCollection : IEnumerable<string>
{
    public string[] Words;

    public IEnumerator<string> GetEnumerator()
    {
        return ((IEnumerable<string>)Words).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return Words.GetEnumerator();
    }

    public LexiconCollection(IEnumerable<string> words)
    {
        Words = words.ToArray();
    }

    public LexiconCollection(TextReader reader)
    {
        Words = ReadFile(reader);
    }

    public LexiconCollection(string filePath)
    {
        using (TextReader reader = new StreamReader(filePath))
        {
            Words = ReadFile(reader);
        }
    }

    public void WriteFile(TextWriter writer)
    {
        writer.WriteLine(string.Join(Environment.NewLine, Words.Select(s => s.Trim()).Where(s => s != "").OrderBy(s => s)));
    }

    public void WriteFile(string filePath)
    {
        using (TextWriter writer = new StreamWriter(filePath))
        {
            WriteFile(writer);
        }
    }

    private static string[] ReadFile(TextReader reader)
    {
        return reader.ReadToEnd().Split(Environment.NewLine)
            .Select(s => s.Trim())
            .Where(s => s != "")
            .ToArray();
    }
}
