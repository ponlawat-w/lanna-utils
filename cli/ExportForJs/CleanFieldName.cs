public static class CleanFieldName
{
    public static string Clean(string name) => string.Concat(name[0].ToString().ToLower(), name.Substring(1));
}
