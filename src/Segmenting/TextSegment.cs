using System.Text;
using System.Text.RegularExpressions;
using LannaUtils.Unicodes;

namespace LannaUtils.Segmenting;

public static class TextSegment
{
    public static string[] Split(string text)
    {
        List<string> results = new List<string>();

        StringBuilder stringBuilder = new StringBuilder();
        for (int i = 0; i < text.Length; i++)
        {
            char currentCharacter = text[i];

            if (
                Regex.IsMatch(currentCharacter.ToString(), $"^[{Patterns.SpatialCharacters}]$")
                && i > 0 && text[i - 1] != Characters.ChoengIndicator
            ) {
                results.Add(stringBuilder.ToString());
                stringBuilder = new StringBuilder();
            }

            stringBuilder.Append(currentCharacter);
        }

        if (stringBuilder.Length > 0)
        {
            results.Add(stringBuilder.ToString());
        }

        return results.ToArray();
    }
}
