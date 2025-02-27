using System.ComponentModel;

namespace HotVars;

public class Hot<T> : INotifyPropertyChanged
{
    protected T _value;
    public T Value
    {
        get => _value;
        private set
        {
            _value = value;
            OnPropertyChanged(nameof(Value));
        }
    }

    public Hot(T value) => _value = value;

    public void SetValue(T value) => Value = value;

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged() =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(string.Empty));

    public void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    public static bool operator ==(Hot<T> hot, T value) => hot?.Value?.Equals(value) ?? false;

    public static bool operator !=(Hot<T> hot, T value) => !hot?.Value?.Equals(value) ?? false;

    public override bool Equals(object? obj) => _value?.Equals(obj) ?? false;

    public override int GetHashCode() => _value!.GetHashCode();

    public override string ToString() => _value!.ToString() ?? string.Empty;
}
