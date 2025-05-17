using System.Collections;

namespace HotVars;

public class HotList<T> : Hot<List<T>>, IEnumerable<T>
{
    public HotList()
        : base(new List<T>()) { }

    public HotList(List<T> value)
        : base(value) { }

    public void Add(T item)
    {
        Value.Add(item);
        OnPropertyChanged();
    }

    public void AddRange(IEnumerable<T> collection)
    {
        Value.AddRange(collection);
        OnPropertyChanged();
    }

    public void Remove(T item)
    {
        Value.Remove(item);
        OnPropertyChanged();
    }

    public void RemoveRange(int index, int count)
    {
        Value.RemoveRange(index, count);
        OnPropertyChanged();
    }

    public void RemoveAll(Predicate<T> match)
    {
        Value.RemoveAll(match);
        OnPropertyChanged();
    }

    public void Clear()
    {
        Value.Clear();
        OnPropertyChanged();
    }

    public void Insert(int index, T item)
    {
        Value.Insert(index, item);
        OnPropertyChanged();
    }

    public void RemoveAt(int index)
    {
        Value.RemoveAt(index);
        OnPropertyChanged();
    }

    public void Sort()
    {
        Value.Sort();
        OnPropertyChanged();
    }

    public void Sort(Comparison<T> comparison)
    {
        Value.Sort(comparison);
        OnPropertyChanged();
    }

    public void Sort(IComparer<T> comparer)
    {
        Value.Sort(comparer);
        OnPropertyChanged();
    }

    public void Sort(int index, int count, IComparer<T> comparer)
    {
        Value.Sort(index, count, comparer);
        OnPropertyChanged();
    }

    public void Reverse()
    {
        Value.Reverse();
        OnPropertyChanged();
    }

    public T this[int key]
    {
        get => Value[key];
        set
        {
            Value[key] = value;
            OnPropertyChanged();
        }
    }

    public int Count => Value.Count;
    public bool IsReadOnly => ((IList<T>)Value).IsReadOnly;

    public int IndexOf(T item) => Value.IndexOf(item);

    public bool Contains(T item) => Value.Contains(item);

    public IEnumerator<T> GetEnumerator()
    {
        return Value.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
