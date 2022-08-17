public static class ExportAmbiguousDescription
{
    public static void Export(string filePath)
    {
        IDictionary<string, object> patterns = new Dictionary<string, object>
        {
            { "initialRegex", AmbiguousDescription.InitialRegex.ToString() },
            { "vowelRegex", AmbiguousDescription.VowelRegex.ToString() },
            { "finalRegex", AmbiguousDescription.FinalRegex.ToString() },
            { "compoundVowelPatterns", CompoundVowelPattern.GetList("compound") },
            { "letterValues", AmbiguousRepresentation.LetterValuesDict },
            { "specialValues", AmbiguousRepresentation.SpecialValuesDict }
        };

        WriteFile.Write(filePath, patterns);
    }
}
