using System.Numerics;

namespace HotVars;

public class HotString : Hot<string>
{
    internal HotString(string value)
        : base(value) { }

    public static HotString From(HotInterpolatedStringHandler builder) => builder.ToHotString();

    public static HotString From(string value) => new(value);

    public static HotString operator +(HotString hot, HotString value) => CalculateSum(hot, value);

    public static HotString operator +(HotString hot, string value) => CalculateSum(hot, value);

    public static HotString operator +(HotString hot, sbyte value) => CalculateSum(hot, value);

    public static HotString operator +(HotString hot, byte value) => CalculateSum(hot, value);

    public static HotString operator +(HotString hot, short value) => CalculateSum(hot, value);

    public static HotString operator +(HotString hot, ushort value) => CalculateSum(hot, value);

    public static HotString operator +(HotString hot, int value) => CalculateSum(hot, value);

    public static HotString operator +(HotString hot, uint value) => CalculateSum(hot, value);

    public static HotString operator +(HotString hot, long value) => CalculateSum(hot, value);

    public static HotString operator +(HotString hot, ulong value) => CalculateSum(hot, value);

    public static HotString operator +(HotString hot, nint value) => CalculateSum(hot, value);

    public static HotString operator +(HotString hot, nuint value) => CalculateSum(hot, value);

    public static HotString operator +(HotString hot, float value) => CalculateSum(hot, value);

    public static HotString operator +(HotString hot, double value) => CalculateSum(hot, value);

    public static HotString operator +(HotString hot, decimal value) => CalculateSum(hot, value);

    public static HotString operator +(HotString hot, BigInteger value) => CalculateSum(hot, value);

    public static HotString operator +(string value, HotString hot) => CalculateSum(value, hot);

    public static HotString operator +(sbyte value, HotString hot) => CalculateSum(hot, value);

    public static HotString operator +(byte value, HotString hot) => CalculateSum(hot, value);

    public static HotString operator +(short value, HotString hot) => CalculateSum(hot, value);

    public static HotString operator +(ushort value, HotString hot) => CalculateSum(hot, value);

    public static HotString operator +(int value, HotString hot) => CalculateSum(hot, value);

    public static HotString operator +(uint value, HotString hot) => CalculateSum(hot, value);

    public static HotString operator +(long value, HotString hot) => CalculateSum(hot, value);

    public static HotString operator +(ulong value, HotString hot) => CalculateSum(hot, value);

    public static HotString operator +(nint value, HotString hot) => CalculateSum(hot, value);

    public static HotString operator +(nuint value, HotString hot) => CalculateSum(hot, value);

    public static HotString operator +(float value, HotString hot) => CalculateSum(hot, value);

    public static HotString operator +(double value, HotString hot) => CalculateSum(hot, value);

    public static HotString operator +(decimal value, HotString hot) => CalculateSum(hot, value);

    public static HotString operator +(BigInteger value, HotString hot) => CalculateSum(hot, value);

    public override bool Equals(object? obj) => Value.Equals(obj);

    public static implicit operator HotString(string value) => new HotString(value);

    public static implicit operator string(HotString value) => value.Value;

    public static implicit operator HotString(HotInterpolatedStringHandler builder) =>
        builder.ToHotString();

    private static HotString CalculateSum(HotString hot, HotString value)
    {
        var sum = new HotString(hot.Value + value.Value);

        hot.PropertyChanged += (sender, args) => sum.SetValue(hot.Value + value.Value);
        value.PropertyChanged += (sender, args) => sum.SetValue(hot.Value + value.Value);

        return sum;
    }

    private static HotString CalculateSum(HotString hot, string value)
    {
        return new HotString(hot.Value + value);
    }

    private static HotString CalculateSum(string value, HotString hot)
    {
        return new HotString(value + hot.Value);
    }

    private static HotString CalculateSum<T>(HotString hot, T value)
        where T : INumber<T>
    {
        return new HotString(hot.Value + value);
    }

    public override int GetHashCode()
    {
        throw new NotImplementedException();
    }
}
