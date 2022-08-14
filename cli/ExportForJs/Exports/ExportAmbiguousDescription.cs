public static class ExportAmbiguousDescription
{
    public static void Export(string filePath)
    {
        IDictionary<string, string> patterns = new Dictionary<string, string>
        {
            { "initialRegex", AmbiguousDescription.InitialRegex.ToString() },
            { "vowelRegex", AmbiguousDescription.VowelRegex.ToString() },
            { "finalRegex", AmbiguousDescription.FinalRegex.ToString() }
        };

        WriteFile.Write(filePath, patterns);
    }
}
