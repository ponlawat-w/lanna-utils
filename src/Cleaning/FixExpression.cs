using System.Text.RegularExpressions;

namespace LannaUtils.Cleaning;

public class FixExpression
{
    public string Name;
    public string Pattern;
    public string Replace;

    public FixExpression(string name, string pattern, string replace)
    {
        Name = name;
        Pattern = pattern;
        Replace = replace;
    }

    public string Apply(string segment) => Regex.Replace(segment, Pattern, Replace);

    public static string ApplyMultiple(IEnumerable<FixExpression> fixExpressions, string str)
    {
        foreach (FixExpression fixExpression in fixExpressions)
        {
            str = fixExpression.Apply(str);
        }
        return str;
    }
}
