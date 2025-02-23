using HotVars;

Console.WriteLine("Example 1: HotNumber");
HotNumber<int> hotNumber = 42;
Console.WriteLine(hotNumber); // 42
hotNumber.PropertyChanged += (sender, args) => Console.WriteLine("HotNumber changed: " + hotNumber);
hotNumber.SetValue(43); // HotNumber changed: 43

Console.WriteLine();
