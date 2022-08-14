class FixExpressionObject
{
    [JsonPropertyName("name")]
    public string Name { get; private set; }

    [JsonPropertyName("pattern")]
    public string Pattern { get; private set; }

    [JsonPropertyName("replace")]
    public string Replace { get; private set; }

    public FixExpressionObject(FixExpression fixExpression)
    {
        Name = fixExpression.Name;
        Pattern = fixExpression.Pattern;
        Replace = CleanReplaceGroupName.Clean(fixExpression.Replace);
    }
}

public class ExportFixExpressions
{
    public static void Export(string filePath)
    {
        IDictionary<string, IEnumerable<FixExpressionObject>> results = new Dictionary<string, IEnumerable<FixExpressionObject>>
        {
            { "fixTextExpressions", FixOrder.FixTextExpressions.Select(s => new FixExpressionObject(s)) },
            { "fixSegmentExpressions", FixOrder.FixSegmentExpressions.Select(s => new FixExpressionObject(s)) }
        };

        WriteFile.Write(filePath, results);
    }
}
