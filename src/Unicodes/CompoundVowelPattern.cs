using System.Text.RegularExpressions;

namespace LannaUtils.Unicodes;

public class CompoundVowelPattern : Regex
{
    public string Pattern { get; private set; }
    public string GroupName { get; private set; }
    public string Value { get; private set; }
    public string AmbiguousValue { get; private set; }
    public bool WithFinalConsonant { get; private set; }

    public CompoundVowelPattern(string pattern, string groupName, string value, string ambiguousValue, bool withFinalConsonant)
    {
        Pattern = $"(?<{groupName}>{pattern})";
        GroupName = groupName;
        Value = value;
        AmbiguousValue = ambiguousValue;
        WithFinalConsonant = withFinalConsonant;
    }

    public static CompoundVowelPattern[] GetList(string groupNamePrefix) => new CompoundVowelPattern[]
    {
        new CompoundVowelPattern(GetPatternOShort(groupNamePrefix), $"{groupNamePrefix}OShort", "o", "o", false),
        new CompoundVowelPattern(GetPatternOShortFinal(groupNamePrefix), $"{groupNamePrefix}OShortFinal", "o", "o", true),
        new CompoundVowelPattern(GetPatternOLongFinal(groupNamePrefix), $"{groupNamePrefix}OLongFinal", "o:", "o", true),
        new CompoundVowelPattern(GetPatternAm(groupNamePrefix), $"{groupNamePrefix}Am", "am", "am", false),
        new CompoundVowelPattern(GetPatternAo(groupNamePrefix), $"{groupNamePrefix}Ao", "ao", "ao", false),
        new CompoundVowelPattern(GetPatternUaLong(groupNamePrefix), $"{groupNamePrefix}UaLong", "ua:", "ua", false),
        new CompoundVowelPattern(GetPatternUaLongFinal(groupNamePrefix), $"{groupNamePrefix}UaLongFinal", "ua:", "ua", true),
        new CompoundVowelPattern(GetPatternUaShort(groupNamePrefix), $"{groupNamePrefix}UaShort", "ua", "ua", false),
        new CompoundVowelPattern(GetPatternUaShortFinal(groupNamePrefix), $"{groupNamePrefix}UaShortFinal", "ua", "ua", true),
        new CompoundVowelPattern(GetPatternUeaShort(groupNamePrefix), $"{groupNamePrefix}UeaShort", "uea", "oe", false),
        new CompoundVowelPattern(GetPatternUeaShortFinal(groupNamePrefix), $"{groupNamePrefix}UeaShortFinal", "uea", "oe", true),
        new CompoundVowelPattern(GetPatternUeaLong(groupNamePrefix), $"{groupNamePrefix}UeaLong", "uea:", "oe", false),
        new CompoundVowelPattern(GetPatternUeaLongFinal(groupNamePrefix), $"{groupNamePrefix}UeaLongFinal", "uea:", "oe", true),
        new CompoundVowelPattern(GetPatternOeShort(groupNamePrefix), $"{groupNamePrefix}OeShort", "oe", "oe", false),
        new CompoundVowelPattern(GetPatternOeShortFinal(groupNamePrefix), $"{groupNamePrefix}OeShortFinal", "oe", "oe", true),
        new CompoundVowelPattern(GetPatternOeLong(groupNamePrefix), $"{groupNamePrefix}OeLong", "oe:", "oe", false),
        new CompoundVowelPattern(GetPatternOeLongFinal(groupNamePrefix), $"{groupNamePrefix}OeLongFinal", "oe:", "oe", true),
        new CompoundVowelPattern(GetPatternOaShort(groupNamePrefix), $"{groupNamePrefix}OaShort", "oa", "oa", false),
        new CompoundVowelPattern(GetPatternOaShortFinal(groupNamePrefix), $"{groupNamePrefix}OaShortFinal", "oa", "oa", true),
        new CompoundVowelPattern(GetPatternOaLong(groupNamePrefix), $"{groupNamePrefix}OaLong", "oa:", "oa", false),
        new CompoundVowelPattern(GetPatternOaLongFinal(groupNamePrefix), $"{groupNamePrefix}OaLongFinal", "oa:", "oa", true),
        new CompoundVowelPattern(GetPatternEShort(groupNamePrefix), $"{groupNamePrefix}EShort", "e", "e", false),
        new CompoundVowelPattern(GetPatternEShortfinal(groupNamePrefix), $"{groupNamePrefix}EShortfinal", "e", "e", true),
        new CompoundVowelPattern(GetPatternAeShort(groupNamePrefix), $"{groupNamePrefix}AeShort", "ae", "ae", false),
        new CompoundVowelPattern(GetPatternAeShortFinal(groupNamePrefix), $"{groupNamePrefix}AeShortFinal", "ae", "ae", true),
        new CompoundVowelPattern(GetPatternAFinal(groupNamePrefix), $"{groupNamePrefix}AFinal", "a", "a", true),
        new CompoundVowelPattern(GetPatternIaShort(groupNamePrefix), $"{groupNamePrefix}IaShort", "ia", "ya", false),
        new CompoundVowelPattern(GetPatternIaShortFinal(groupNamePrefix), $"{groupNamePrefix}IaShortFinal", "ia", "ya", true),
        new CompoundVowelPattern(GetPatternIaLong(groupNamePrefix), $"{groupNamePrefix}IaLong", "ia:", "ya", false),
        new CompoundVowelPattern(GetPatternIaLongFinal(groupNamePrefix), $"{groupNamePrefix}IaLongFinal", "ia:", "ya", true),
        new CompoundVowelPattern(GetPatternOPali(groupNamePrefix), $"{groupNamePrefix}OPali", "o:", "o", false)
    };

    private static string GetPatternOShort(string prefix) => $@"\u1A70[\u1A6B]?(?<{prefix}OShortTone>[{Patterns.Tones}]?)\u1A61";
    private static string GetPatternOShortFinal(string prefix) => $@"\u1A6B(?<{prefix}OShortFinalTone>[{Patterns.Tones}]?)";
    private static string GetPatternOLongFinal(string prefix) => $@"\u1A70[\u1A6B]?(?<{prefix}OLongFinalTone>[{Patterns.Tones}]?)";
    private static string GetPatternAm(string prefix) => $@"[\u1A63\u1A64]\u1A74(?<{prefix}AmTone>[{Patterns.Tones}]?)";
    private static string GetPatternAo(string prefix) => $@"\u1A6E\u1A62(?<{prefix}AoTone>[{Patterns.Tones}]?)[\u1A63\u1A64]";
    private static string GetPatternUaLong(string prefix) => $@"\u1A60\u1A45\u1A6B(?<{prefix}UaLongTone>[{Patterns.Tones}]?)";
    private static string GetPatternUaLongFinal(string prefix) => $@"\u1A60\u1A45(?<{prefix}UaLongFinalTone>[{Patterns.Tones}]?)";
    private static string GetPatternUaShort(string prefix) => $@"\u1A60\u1A45\u1A6B(?<{prefix}UaShortTone>[{Patterns.Tones}]?)\u1A61";
    private static string GetPatternUaShortFinal(string prefix) => $@"\u1A60\u1A45\u1A6B\u1A62(?<{prefix}UaShortFinalTone>[{Patterns.Tones}]?)";
    private static string GetPatternUeaShort(string prefix) => $@"\u1A6E\u1A6C\u1A65(?<{prefix}UeaShortTone>[{Patterns.Tones}]?)\u1A4B\u1A61";
    private static string GetPatternUeaShortFinal(string prefix) => $@"\u1A6E\u1A6C\u1A65\u1A62(?<{prefix}UeaShortFinalTone>[{Patterns.Tones}]?)";
    private static string GetPatternUeaLong(string prefix) => $@"\u1A6E\u1A6C\u1A65(?<{prefix}UeaLongTone>[{Patterns.Tones}]?)\u1A4B";
    private static string GetPatternUeaLongFinal(string prefix) => $@"\u1A6E\u1A6C\u1A65(?<{prefix}UeaLongFinalTone>[{Patterns.Tones}]?)";
    private static string GetPatternOeShort(string prefix) => $@"\u1A6E\u1A6C\u1A65(?<{prefix}OeShortTone>[{Patterns.Tones}]?)\u1A61";
    private static string GetPatternOeShortFinal(string prefix) => $@"\u1A6E\u1A65\u1A62(?<{prefix}OeShortFinalTone>[{Patterns.Tones}]?)";
    private static string GetPatternOeLong(string prefix) => $@"\u1A6E\u1A6C\u1A65(?<{prefix}OeLongTone>[{Patterns.Tones}]?)";
    private static string GetPatternOeLongFinal(string prefix) => $@"\u1A6E\u1A65(?<{prefix}OeLongFinalTone>[{Patterns.Tones}]?)";
    private static string GetPatternOaShort(string prefix) => $@"\u1A70\u1A6C(?<{prefix}OaShortTone>[{Patterns.Tones}]?)\u1A61";
    private static string GetPatternOaShortFinal(string prefix) => $@"\u1A6C\u1A62(?<{prefix}OaShortFinalTone>[{Patterns.Tones}]?)";
    private static string GetPatternOaLong(string prefix) => $@"\u1A6C\u1A74(?<{prefix}OaLongTone>[{Patterns.Tones}]?)";
    private static string GetPatternOaLongFinal(string prefix) => $@"\u1A6C(?<{prefix}OaLongFinalTone>[{Patterns.Tones}]?)";
    private static string GetPatternEShort(string prefix) => $@"\u1A6E(?<{prefix}EShortTone>[{Patterns.Tones}]?)\u1A61";
    private static string GetPatternEShortfinal(string prefix) => $@"\u1A6E\u1A62(?<{prefix}EShortfinalTone>[{Patterns.Tones}]?)";
    private static string GetPatternAeShort(string prefix) => $@"\u1A6F(?<{prefix}AeShortTone>[{Patterns.Tones}]?)\u1A61";
    private static string GetPatternAeShortFinal(string prefix) => $@"\u1A6F\u1A62(?<{prefix}AeShortFinalTone>[{Patterns.Tones}]?)";
    private static string GetPatternAFinal(string prefix) => $@"\u1A62(?<{prefix}AFinalTone>[{Patterns.Tones}]?)";
    private static string GetPatternIaShort(string prefix) => $@"\u1A6E\u1A60\u1A3F(?<{prefix}IaShortTone>[{Patterns.Tones}]?)\u1A61";
    private static string GetPatternIaShortFinal(string prefix) => $@"\u1A62\u1A60\u1A3F(?<{prefix}IaShortFinalTone>[{Patterns.Tones}]?)";
    private static string GetPatternIaLong(string prefix) => $@"\u1A6E\u1A60\u1A3F(?<{prefix}IaLongTone>[{Patterns.Tones}]?)";
    private static string GetPatternIaLongFinal(string prefix) => $@"\u1A60\u1A3F(?<{prefix}IaLongFinalTone>[{Patterns.Tones}]?)";
    private static string GetPatternOPali(string prefix) => $@"\u1A6E(?<{prefix}OPaliTone>[{Patterns.Tones}]?)[\u1A63\u1A64]";
}
