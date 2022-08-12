string lexiconPath = Environment.GetCommandLineArgs()[1];

if (!File.Exists(lexiconPath))
{
    throw new FileNotFoundException();
}

LannaUtils.Lexicon.LexiconCollection collection = new LannaUtils.Lexicon.LexiconCollection(lexiconPath);
collection.Words = collection.Words.Select(w => LannaUtils.Cleaning.FixOrder.Fix(w))
    .Distinct()
    .ToArray();

collection.WriteFile(lexiconPath);
