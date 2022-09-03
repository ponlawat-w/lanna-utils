using System.Text.RegularExpressions;
using LannaUtils.Unicodes;

namespace LannaUtils.Segmenting;

public class SegmentExplanation
{
    public static string Pattern =
        $"^(?<central>[{Patterns.SpatialCharacters}])+"
        + $"(?<rightTop>{Patterns.UpperMaikanglai}+)?"
        + $"(?<centralLeft>[{Patterns.LeftComponents}]+)?"
        + $"(?<bottom1>(([{Patterns.LowerCharacters}])+|({Patterns.Choeng}[{Patterns.ChoengableLetters}])+)*)"
        + $"(?<left>[{Patterns.LeftVowels}]+)?"
        + $"(?<bottom2>(([{Patterns.LowerCharacters}])+|({Patterns.Choeng}[{Patterns.ChoengableLetters}])+)*)"
        + $"(?<top1>[{Patterns.UpperCharacters}]+)*"
        + $"(?<bottom3>(([{Patterns.LowerCharacters}])+|({Patterns.Choeng}[{Patterns.ChoengableLetters}])+)*)"
        + $"(?<right>[{Patterns.RightCharacters}]+)?"
        + $"(?<top2>[{Patterns.UpperCharacters}]+)*"
        + $"(?<rightBottom>(([{Patterns.LowerCharacters}])+|({Patterns.Choeng}[{Patterns.ChoengableLetters}])+)*)$";

    public bool Valid = false;
    public string Central = "";
    public string CentralLeft = "";
    public string Left = "";
    public string Top = "";
    public string Right = "";
    public string RightTop = "";
    public string RightBottom = "";
    public string Bottom = "";

    public SegmentExplanation(string segment = "")
    {
        Match match = Regex.Match(segment, Pattern);
        if (!match.Success)
        {
            return;
        }
        Valid = true;
        Central = match.Groups["central"].Value;
        CentralLeft = match.Groups["centralLeft"].Success ? match.Groups["centralLeft"].Value : "";
        Left = match.Groups["left"].Success ? match.Groups["left"].Value : "";
        Top = (match.Groups["top1"].Success ? match.Groups["top1"].Value : "")
            + (match.Groups["top2"].Success ? match.Groups["top2"].Value : "");
        Right = match.Groups["right"].Success ? match.Groups["right"].Value : "";
        RightTop = match.Groups["rightTop"].Success ? match.Groups["rightTop"].Value : "";
        RightBottom = match.Groups["rightBottom"].Success ? match.Groups["rightBottom"].Value.Replace(Characters.SignSakot.ToString(), "") : "";
        Bottom = (match.Groups["bottom1"].Success ? match.Groups["bottom1"].Value.Replace(Characters.SignSakot.ToString(), "") : "")
            + (match.Groups["bottom2"].Success ? match.Groups["bottom2"].Value.Replace(Characters.SignSakot.ToString(), "") : "")
            + (match.Groups["bottom3"].Success ? match.Groups["bottom3"].Value.Replace(Characters.SignSakot.ToString(), "") : "");
        
        if (Central == Characters.LetterNa.ToString() && Right == Characters.VowelSignAa.ToString())
        {
            Central = Characters.LetterNa.ToString() + Characters.VowelSignAa.ToString();
            Right = "";
            Bottom += RightBottom;
            RightBottom = "";
        }
    }
}
