using HotVars;

Console.WriteLine("Example 1: HotNumber");
HotNumber<int> hotNumber = 42;
Console.WriteLine(hotNumber); // 42

hotNumber.PropertyChanged += (sender, args) => Console.WriteLine("HotNumber changed: " + hotNumber);
hotNumber.SetValue(43); // HotNumber changed: 43

Console.WriteLine();

Console.WriteLine("Example 2: HotString");
var hotString = new HotString("Hello ");

Console.WriteLine(hotString); // Hello
hotString.PropertyChanged += (sender, args) => Console.WriteLine("HotString changed: " + hotString);
hotString.SetValue(hotString.Value + "World"); // HotString changed: Hello World

Console.WriteLine();

Console.WriteLine("Example 3: Hot Interpolated String");
var hotInterpolatedString = HotString.From($"Hello {hotNumber}");
Console.WriteLine(hotInterpolatedString); // Hello 43
hotInterpolatedString.PropertyChanged += (sender, args) =>
    Console.WriteLine("HotInterpolatedString changed: " + hotInterpolatedString);
hotNumber.SetValue(44); // HotInterpolatedString changed: Hello 44
