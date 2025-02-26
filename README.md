# HotVars

Signal-like classes for C#.

```c#
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
var increment = new HotNumber<int>(1);
var name = new HotString("Alice");
var hotInterpolatedString = HotString.From($"Hello {name}! {increment}"); // Hello Alice! 1

Console.WriteLine(hotInterpolatedString); // Hello Alice! 1
hotInterpolatedString.PropertyChanged += (sender, args) =>
    Console.WriteLine("HotInterpolatedString changed: " + hotInterpolatedString);
increment.SetValue(2); // HotInterpolatedString changed: Hello Alice! 2
name.SetValue("Bob"); // HotInterpolatedString changed: Hello Bob! 2
increment.SetValue(3); // HotInterpolatedString changed: Hello Bob! 3
```