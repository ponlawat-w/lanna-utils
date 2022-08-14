string outputDir = Environment.GetCommandLineArgs()[1];

Directory.CreateDirectory(outputDir);

Console.WriteLine("Exporting characters...");
ExportCharacters.Export(Path.Join(outputDir, "characters.json"));

Console.WriteLine("Exporting patterns...");
ExportPatterns.Export(Path.Join(outputDir, "patterns.json"));

Console.WriteLine("Exporting fix expressions...");
ExportFixExpressions.Export(Path.Join(outputDir, "fix-expressions.json"));

Console.WriteLine("Exporting ambiguous description...");
ExportAmbiguousDescription.Export(Path.Join(outputDir, "ambiguous-description.json"));

Console.WriteLine("Done");
