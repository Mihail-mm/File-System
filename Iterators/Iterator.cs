using System.Collections;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.Iterators;

public class Iterator : IEnumerable<string>
{
    private readonly IList<string> _collection;
    private int _position;

    public Iterator(IList<string> list)
    {
        _collection = list;
    }

    public string Current => _collection[_position];

    public bool MoveNext()
    {
        _position++;
        return _position < _collection.Count;
    }

    public void Reset()
    {
        _position = 0;
    }

    public IEnumerator<string> GetEnumerator()
    {
        return _collection.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}