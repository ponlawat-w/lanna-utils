string outputDir = Environment.GetCommandLineArgs()[1];

Directory.CreateDirectory(outputDir);

Console.WriteLine("Exporting characters...");
ExportCharacters.Export(Path.Join(outputDir, "characters.ts"));

Console.WriteLine("Exporting patterns...");
ExportPatterns.Export(Path.Join(outputDir, "patterns.ts"));

Console.WriteLine("Exporting fix expressions...");
ExportFixExpressions.Export(Path.Join(outputDir, "fix-expressions.ts"));

Console.WriteLine("Exporting ambiguous description...");
ExportAmbiguousDescription.Export(Path.Join(outputDir, "ambiguous-description.ts"));

Console.WriteLine("Done");
