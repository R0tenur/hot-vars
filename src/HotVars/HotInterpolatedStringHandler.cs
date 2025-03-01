using System.ComponentModel;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace HotVars;

[InterpolatedStringHandler]
public class HotInterpolatedStringHandler(int literalLength, int formattedCount)
    : INotifyPropertyChanged
{
    private HotString Builder { get; set; } = new HotString("");

    internal readonly List<Func<string>> _fragments = [];
    internal readonly List<Func<string>> _formatted = [];

    public event PropertyChangedEventHandler? PropertyChanged;

    public void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    public void AppendLiteral(string s) => _fragments.Add(() => s);

    public HotString ToHotString() => new(this);

    public void AppendFormatted(HotString t)
    {
        _fragments.Add(() => t.Value);
        t.PropertyChanged += (sender, args) => OnPropertyChanged(string.Empty);
    }

    public void AppendFormatted(string t)
    {
        _fragments.Add(() => t);
    }

    public void AppendFormatted<T>(HotNumber<T> t)
        where T : INumber<T>
    {
        _fragments.Add(() => t.ToString());
        t.PropertyChanged += (sender, args) => OnPropertyChanged("value");
    }

    public void AppendFormatted<T>(Hot<T> t)
    {
        _fragments.Add(() => t.ToString());
        t.PropertyChanged += (sender, args) => OnPropertyChanged("value");
    }
}
