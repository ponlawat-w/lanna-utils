public static class CleanReplaceGroupName
{
    public static string Clean(string name) => name.Replace("{", "<").Replace("}", ">");
}
