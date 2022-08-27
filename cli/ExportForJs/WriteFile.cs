public static class WriteFile
{
    public static void Write(string filePath, object value)
    {
        using (TextWriter writer = new StreamWriter(filePath))
        {
            writer.Write("export default " + JsonSerializer.Serialize(value, new JsonSerializerOptions
            {
                WriteIndented = true
            }) + ';');
        }
    }
}
