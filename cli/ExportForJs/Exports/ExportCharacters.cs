public static class ExportCharacters
{
    public static void Export(string filePath)
    {
        IDictionary<string, string?> value = typeof(Characters).GetFields()
            .Where(f => f.FieldType == typeof(char))
            .ToDictionary(
                f => CleanFieldName.Clean(f.Name),
                f => (string?)((char?)f.GetValue(null) ?? null)?.ToString() ?? null
            );
        
        WriteFile.Write(filePath, value);
    }
}
