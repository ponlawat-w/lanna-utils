using System.Text;
using System.Text.RegularExpressions;
using LannaUtils.Unicodes;

namespace LannaUtils.Transforming;

public static class AmbiguousDescription
{
    private readonly static CompoundVowelPattern[] _compoundVowelPatterns = CompoundVowelPattern.GetList("compound");

    public readonly static Regex InitialRegex = new Regex(
        $"^((?<special>" + string.Join("|", AmbiguousRepresentation.SpecialValuesDict.Select(x => x.Key)) + "$)?|"
        + $"((?<haCombination>{Patterns.LetterHighHa}{Patterns.Choeng}(?<afterHaLetter>[{Patterns.AfterHaLetters}]))|(?<compoundInitial>(?<compoundMain>[{Patterns.SpatialCharacters}])(?<compoundChoeng>{Patterns.Choeng}(?<compoundChoengLetter>[{Patterns.ChoengableLettersExceptYaWa}]))+)|(?<singleInitial>[{Patterns.SpatialCharacters}]))"
        + $"(?<leftComponent>[{Patterns.LeftComponents}])?(?<lowerComponent>[{Patterns.LowerComponents}{Patterns.LowerToRightComponents}])?(?<maisam>{Patterns.UpperMaisam})?(?<remaining>.*))$"
    );

    public readonly static Regex VowelRegex = new Regex(
        $"^(?<startTone>[{Patterns.Tones}])?(?<vowel>(?<compound>" + (string.Join("|", _compoundVowelPatterns.Select(x => x.Pattern))) + ")"
        + $"|(?<single>(?<singleToneBefore>[{Patterns.Tones}])?(?<singleVowel>[{Patterns.Vowels}])(?<singleToneAfter>[{Patterns.Tones}])?))?"
        + $"(?<remaining>.*)$"
    );

    public readonly static Regex FinalRegex = new Regex(
        $"^(?<any1>.+)?(?<choeng>{Patterns.Choeng}(?<choengLetters>[{Patterns.ChoengableLetters}]))+(?<any2>.+)?$"
    );

    public static string Describe(string word) => string.Join("", Segmenting.TextSegment.Split(word).Select(segment => DescribeSegment(segment)));

    private static string DescribeSegment(string segment) => GetInitial(segment, out segment) + GetVowel(segment, out segment) + GetFinal(segment);

    private static string GetInitial(string segment, out string remainingSegment)
    {
        Match match = InitialRegex.Match(segment);
        if (!match.Success)
        {
            remainingSegment = segment;
            return "?";
        }

        if (match.Groups["special"].Success)
        {
            remainingSegment = "";
            return AmbiguousRepresentation.GetSpecialValue(match.Groups["special"].Value);
        }

        StringBuilder stringBuilder = new StringBuilder();

        if (match.Groups["haCombination"].Success)
        {
            stringBuilder.Append(AmbiguousRepresentation.GetValue(match.Groups["afterHaLetter"].Value));
        }
        else if (match.Groups["singleInitial"].Success)
        {
            stringBuilder.Append(AmbiguousRepresentation.GetValue(match.Groups["singleInitial"].Value));
        }
        else if (match.Groups["compoundInitial"].Success)
        {
            stringBuilder.Append(AmbiguousRepresentation.GetValue(match.Groups["compoundMain"].Value));
            foreach (Capture capture in match.Groups["compoundChoengLetter"].Captures)
            {
                stringBuilder.Append(AmbiguousRepresentation.GetValue(capture.Value));
            }
        }

        if (match.Groups["leftComponent"].Success)
        {
            stringBuilder.Append(AmbiguousRepresentation.GetValue(match.Groups["leftComponent"].Value));
        }
        if (match.Groups["lowerComponent"].Success)
        {
            stringBuilder.Append(AmbiguousRepresentation.GetValue(match.Groups["lowerComponent"].Value));
        }

        remainingSegment = match.Groups["remaining"].Success ? match.Groups["remaining"].Value : "";
        return stringBuilder.ToString();
    }

    private static string GetVowel(string processedSegment, out string remainingSegment)
    {
        Match match = VowelRegex.Match(processedSegment);

        remainingSegment = match.Groups["remaining"].Success ? match.Groups["remaining"].Value : "";

        if (match.Groups["compound"].Success)
        {
            foreach (CompoundVowelPattern pattern in _compoundVowelPatterns)
            {
                if (match.Groups[pattern.GroupName].Success)
                {
                    return pattern.AmbiguousValue;
                }
            }
            return "?";
        }
        else if (match.Groups["single"].Success)
        {
            return AmbiguousRepresentation.GetValue(match.Groups["singleVowel"].Value);
        }

        return "";
    }

    private static string GetFinal(string processedSegment)
    {
        Match match = FinalRegex.Match(processedSegment);

        StringBuilder stringBuilder = new StringBuilder();

        if (match.Groups["any1"].Success)
        {
            stringBuilder.Append(AmbiguousRepresentation.GetValue(match.Groups["any1"].Value));
        }

        if (match.Groups["choeng"].Success)
        {
            foreach (Capture capture in match.Groups["choengLetters"].Captures)
            {
                stringBuilder.Append(AmbiguousRepresentation.GetValue(capture.Value));
            }
        }

        if (match.Groups["any2"].Success)
        {
            stringBuilder.Append(AmbiguousRepresentation.GetValue(match.Groups["any2"].Value));
        }

        return stringBuilder.ToString();
    }
}
