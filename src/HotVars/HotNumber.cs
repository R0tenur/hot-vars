using System.Numerics;

namespace HotVars;

public class HotNumber<T> : Hot<T>
    where T : INumber<T>
{
    public HotNumber(T value)
        : base(value) { }

    public static bool operator <(HotNumber<T> hot, T Value) => hot.Value < Value;

    public static bool operator <=(HotNumber<T> hot, T Value) => hot.Value <= Value;

    public static bool operator ==(HotNumber<T> hot, HotNumber<T> Value) =>
        hot.Value == Value.Value;

    public static bool operator !=(HotNumber<T> hot, HotNumber<T> Value) =>
        hot.Value != Value.Value;

    public static bool operator >=(HotNumber<T> hot, T Value) => hot.Value >= Value;

    public static bool operator >(HotNumber<T> hot, T Value) => hot.Value > Value;

    public static HotNumber<T> operator +(HotNumber<T> hot, HotNumber<T> value) =>
        CalculateSum(hot, value);

    public static HotString operator +(HotNumber<T> hot, string value) => CalculateSum(hot, value);

    public static HotNumber<T> operator +(HotNumber<T> hot, T value) =>
        HotNumber<T>.CalculateSum(hot, value);

    public static HotString operator +(HotString hot, HotNumber<T> value) =>
        CalculateSum(hot, value);

    public static HotString operator +(HotNumber<T> value, HotString hot) =>
        CalculateSum(value, hot);

    public static HotString operator +(string value, HotNumber<T> hot) => CalculateSum(value, hot);

    public static implicit operator HotNumber<T>(T v) => new HotNumber<T>(v);

    public override bool Equals(object? obj) => Value.Equals(obj);

    private static HotNumber<T> CalculateSum(Hot<T> hot, Hot<T> value)
    {
        var sum = new HotNumber<T>(hot.Value + value.Value);

        hot.PropertyChanged += (sender, args) => sum.SetValue(hot.Value + value.Value);
        value.PropertyChanged += (sender, args) => sum.SetValue(hot.Value + value.Value);

        return sum;
    }

    private static HotString CalculateSum(Hot<T> hot, string value)
    {
        var sum = new HotString(hot.Value + value);

        hot.PropertyChanged += (sender, args) => sum.SetValue(hot.Value + value);

        return sum;
    }

    private static HotString CalculateSum(string value, Hot<T> hot)
    {
        var sum = new HotString(value + hot.Value);

        hot.PropertyChanged += (sender, args) => sum.SetValue(value + hot.Value);

        return sum;
    }

    private static HotNumber<T> CalculateSum(Hot<T> hot, T value)
    {
        var sum = new HotNumber<T>(hot.Value + value);

        hot.PropertyChanged += (sender, args) => sum.SetValue(hot.Value + value);

        return sum;
    }

    private static HotString CalculateSum(HotString hot, Hot<T> value)
    {
        var sum = new HotString(hot.Value + value.Value);

        hot.PropertyChanged += (sender, args) => sum.SetValue(hot.Value + value.Value);
        value.PropertyChanged += (sender, args) => sum.SetValue(hot.Value + value.Value);

        return sum;
    }

    private static HotString CalculateSum(Hot<T> value, HotString hot)
    {
        var sum = new HotString(value.Value + hot.Value);

        hot.PropertyChanged += (sender, args) => sum.SetValue(value.Value + hot.Value);
        value.PropertyChanged += (sender, args) => sum.SetValue(value.Value + hot.Value);

        return sum;
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }
}
