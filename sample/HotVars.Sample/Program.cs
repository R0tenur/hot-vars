using HotVars;

Console.WriteLine("Example 1: HotNumber");
HotNumber<int> hotNumber = 42;
Console.WriteLine(hotNumber); // 42
hotNumber.PropertyChanged += (sender, args) => Console.WriteLine("HotNumber changed: " + hotNumber);
hotNumber.SetValue(43); // HotNumber changed: 43

Console.WriteLine();

Console.WriteLine("Example 2: HotString");
HotString hotString = "Hello ";

Console.WriteLine(hotString); // Hello
hotString.PropertyChanged += (sender, args) => Console.WriteLine("HotString changed: " + hotString);
hotString.SetValue(hotString + "World"); // HotString changed: Hello World

Console.WriteLine();
