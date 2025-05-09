using TCC.Logic.Factory;

Console.WriteLine("Geben Sie einen Eingabetext ein: ");
string input = Console.ReadLine()!;

var mockImpl = ApplicableAlgorithmFactory.CreateHuffmanAlgorithm(input);

Console.WriteLine($"Output: {mockImpl.Output}");
Console.WriteLine($"Input Size: {mockImpl.Statistic.InputSize}");
Console.WriteLine($"Output Size: {mockImpl.Statistic.OutputSize}");
Console.WriteLine($"Statistik: {mockImpl.Statistic.SizeDifference} byte => {Math.Round(mockImpl.Statistic.SavedSizePercent, 2)}% saved");
