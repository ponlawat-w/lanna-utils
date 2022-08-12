// See https://aka.ms/new-console-template for more information
string inputPath = Environment.GetCommandLineArgs()[1];
string outputPath = Environment.GetCommandLineArgs()[2];

LannaUtils.Lexicon.LexiconCollection lexicon = new LannaUtils.Lexicon.LexiconCollection(inputPath);
LannaUtils.Lexicon.PossibleWordsGenerator possibleWordsGenerator = new LannaUtils.Lexicon.PossibleWordsGenerator(lexicon);
possibleWordsGenerator.Report = true;
LannaUtils.Lexicon.LexiconCollection possibleWords = new LannaUtils.Lexicon.LexiconCollection(possibleWordsGenerator.Generate());
possibleWords.WriteFile(outputPath);
