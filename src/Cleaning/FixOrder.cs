using LannaUtils.Segmenting;
using LannaUtils.Unicodes;

namespace LannaUtils.Cleaning;

public static class FixOrder
{
    public static readonly FixExpression[] FixTextExpressions = new FixExpression[]
    {
        new FixExpression(
            "FixDanglingChoeng",
            $"([{Patterns.Choeng}])([^{Patterns.ChoengableLetters}])+([{Patterns.ChoengableLetters}])",
            "$1$3$2"
        ),
        new FixExpression(
            "FixLeftVowels",
            $@"(^|\s)(?<left>[{Patterns.LeftVowels}])(?<main>[{Patterns.SpatialCharacters}][{Patterns.LeftCharacters}]?)",
            "${main}${left}"
        )
    };

    public static readonly FixExpression[] FixSegmentExpressions = new FixExpression[]
    {
        new FixExpression(
            "FixUa",
            $"^(.+)({Patterns.UpperVowelO})([{Patterns.Tones}]?)({Patterns.Choeng}[{Patterns.ChoengableLetters}])?({Patterns.Choeng}{Patterns.LetterWa})(.*)",
            "$1$4$5$2$3$6"
        ),
        new FixExpression(
            "FixAa",
            $"^(?<letters>[{Patterns.TallAaLetters}])(?<components>([{Patterns.NonRightCharacters}])*({Patterns.Choeng}[{Patterns.LowerChoengLetters}])*([{Patterns.NonRightCharacters}])*)?(?<aa>{Patterns.RightVowelAa})(?<final>.*)?",
            "${letters}${components}" + Characters.VowelSignTallAa + "${final}"
        ),
        new FixExpression(
            "FixOa",
            $"^(.+)({Patterns.UpperMaikang})([{Patterns.Tones}]?)({Patterns.LowerVowelOa})(.*)",
            "$1$4$2$3$5"
        ),
        new FixExpression(
            "FixAm",
            $"^(.+)({Patterns.UpperMaikang})([{Patterns.Tones}]?)({Patterns.RightVowelAa}|{Patterns.RightVowelTallAa})",
            "$1$4$2$3"
        ),
        new FixExpression(
            "FixIa",
            $"(?<uayCase>(?<uayInit>^[{Patterns.SpatialCharacters}]([{Patterns.LeftComponents}])?([{Patterns.LowerComponents}])?({Patterns.Choeng}[{Patterns.ChoengableLettersExceptYaWa}])?)(?<uayTone1>[{Patterns.Tones}]?)(?<uayCw>{Patterns.ChoengWa})(?<uayCy>{Patterns.ChoengYa})(?<uayTone2>[{Patterns.Tones}]?)"
                + $")|(?<nonUay>(?<init>^[{Patterns.SpatialCharacters}]([{Patterns.LeftComponents}])?([{Patterns.LowerComponents}])?({Patterns.Choeng}[{Patterns.ChoengableLettersExceptYaWa}])?)"
                    + $"((?<iaCase>(?<iaCaseE>{Patterns.LeftVowelE})(?<iaCaseCy>{Patterns.ChoengYa})(?<iaCaseTone>[{Patterns.Tones}]?))"
                    + $"|(?<iaFinalCase>(?<iaFinalCaseTone>[{Patterns.Tones}]?)(?<iaFinalCaseCy>{Patterns.ChoengYa}))"
                    + $"|(?<finalYaCase>(?<finalYaCaseTone>[{Patterns.Tones}]?)(?<finalYaCaseVowel>([{Patterns.LowerVowels}])|({Patterns.ChoengWa}))(?<finalYaCaseCy>{Patterns.ChoengYa})))"
                + $")",
            "${uayInit}${uayCw}${uayTone1}${uayTone2}${uayCy}${init}${iaCaseE}${iaCaseTone}${iaCaseCy}${iaFinalCaseCy}${iaFinalCaseTone}${finalYaCaseVowel}${finalYaCaseTone}${finalYaCaseCy}"
        ),
        new FixExpression(
            "FixLowVowelTone",
            $"^(.+)([{Patterns.Tones}])([{Patterns.LowerVowels}])(.*)",
            "$1$3$2$4"
        ),
        new FixExpression(
            "FixUea",
            $"^(?<init>.+)(?<e>{Patterns.LeftVowelE})(?<i>{Patterns.UpperVowelI}[{Patterns.Tones}]?)?(?<o>{Patterns.LowerVowelOa})(?<rest>.*)",
            "${init}${e}${o}${i}${rest}"
        ),
        new FixExpression(
            "FixWater",
            $"(ᨶᩴ᩶ᩣ|ᨶᩣ᩶ᩴ|ᨶ᩶ᩣᩴ|ᨶᩴᩣ᩶)",
            "ᨶᩣᩴ᩶"
        )
    };

    public static string Fix(string text) => string.Join("", TextSegment.Split(
        FixExpression.ApplyMultiple(FixTextExpressions, text)
    ).Select(segment => FixExpression.ApplyMultiple(FixSegmentExpressions, segment)));
}
