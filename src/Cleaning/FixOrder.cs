using System.Text.RegularExpressions;
using LannaUtils.Segmenting;
using LannaUtils.Unicodes;

namespace LannaUtils.Cleaning;

public static class FixOrder
{
    public static string Fix(string input) => string.Join("",
        TextSegment.Split(FixDangling(input)).Select(s => FixWater(FixLowVowelTone(FixIa(FixAm(FixOa(FixAa(FixUa(s))))))))
    );

    private static string FixDangling(string input) => Regex.Replace(
        input,
        $"([{Patterns.Choeng}])([^{Patterns.ChoengableLetters}])+([{Patterns.ChoengableLetters}])",
        "$1$3$2"
    );

    private static string FixUa(string segment) => Regex.Replace(
        segment,
        $"^(.+)({Patterns.UpperVowelO})([{Patterns.Tones}]?)({Patterns.Choeng}[{Patterns.ChoengableLetters}])?({Patterns.Choeng}{Patterns.LetterWa})(.*)",
        "$1$4$5$2$3$6"
    );

    private static string FixAa(string segment) => Regex.Replace(
        segment,
        $"^(?<letters>[{Patterns.TallAaLetters}])(?<components>([{Patterns.NonRightCharacters}])*({Patterns.Choeng}[{Patterns.LowerChoengLetters}])*([{Patterns.NonRightCharacters}])*)?(?<aa>{Patterns.RightVowelAa})(?<final>.*)?",
        "${letters}${components}" + Characters.VowelSignTallAa + "${final}"
    );

    private static string FixOa(string segment) => Regex.Replace(
        segment,
        $"^(.+)({Patterns.UpperMaikang})([{Patterns.Tones}]?)({Patterns.LowerVowelOa})(.*)",
        "$1$4$2$3$5"
    );

    private static string FixAm(string segment) => Regex.Replace(
        segment,
        $"^(.+)({Patterns.UpperMaikang})([{Patterns.Tones}]?)({Patterns.RightVowelAa}|{Patterns.RightVowelTallAa})",
        "$1$4$2$3"
    );

    private static string FixIa(string segment) => Regex.Replace(
        segment,
        $"(?<uayCase>(?<uayInit>^[{Patterns.SpatialCharacters}]([{Patterns.LeftComponents}])?([{Patterns.LowerComponents}])?({Patterns.Choeng}[{Patterns.ChoengableLettersExceptYaWa}])?)(?<uayTone1>[{Patterns.Tones}]?)(?<uayCw>{Patterns.ChoengWa})(?<uayCy>{Patterns.ChoengYa})(?<uayTone2>[{Patterns.Tones}]?)"
            + $")|(?<nonUay>(?<init>^[{Patterns.SpatialCharacters}]([{Patterns.LeftComponents}])?([{Patterns.LowerComponents}])?({Patterns.Choeng}[{Patterns.ChoengableLettersExceptYaWa}])?)"
                + $"((?<iaCase>(?<iaCaseE>{Patterns.LeftVowelE})(?<iaCaseCy>{Patterns.ChoengYa})(?<iaCaseTone>[{Patterns.Tones}]?))"
                + $"|(?<iaFinalCase>(?<iaFinalCaseTone>[{Patterns.Tones}]?)(?<iaFinalCaseCy>{Patterns.ChoengYa}))"
                + $"|(?<finalYaCase>(?<finalYaCaseTone>[{Patterns.Tones}]?)(?<finalYaCaseVowel>([{Patterns.LowerVowels}])|({Patterns.ChoengWa}))(?<finalYaCaseCy>{Patterns.ChoengYa})))"
            + $")",
        "${uayInit}${uayCw}${uayTone1}${uayTone2}${uayCy}${init}${iaCaseE}${iaCaseTone}${iaCaseCy}${iaFinalCaseCy}${iaFinalCaseTone}${finalYaCaseVowel}${finalYaCaseTone}${finalYaCaseCy}"
    );

    private static string FixLowVowelTone(string segment) => Regex.Replace(
        segment,
        $"^(.+)([{Patterns.Tones}])([{Patterns.LowerVowels}])(.*)",
        "$1$3$2$4"
    );

    private static string FixWater(string segment) => segment.Length == 4 &&
        segment.Contains(Characters.LetterNa) && segment.Contains(Characters.VowelSignAa)
        && segment.Contains(Characters.SignMaiKang) && segment.Contains(Characters.SignTone2)
        ? $"{Characters.LetterNa}{Characters.VowelSignAa}{Characters.SignMaiKang}{Characters.SignTone2}" : segment;
}
