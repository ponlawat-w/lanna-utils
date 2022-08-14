public static class ExportPatterns
{
    public static void Export(string filePath)
    {
        IDictionary<string, string?> value = typeof(Patterns).GetFields()
            .Where(f => f.FieldType == typeof(string))
            .ToDictionary(
                f => CleanFieldName.Clean(f.Name),
                f => (string?)(f.GetValue(null) ?? null)
            );
        
        WriteFile.Write(filePath, value);
    }
}
