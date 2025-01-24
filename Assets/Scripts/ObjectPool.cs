using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class ObjectPool <T>
{

    private T[] values;
    private Queue<T> _pool;
    private int _index = 0;
    private int _maxIndex = 0;

    public ObjectPool(T[] values)
    {
        _pool = new Queue<T>();
        this.values = values;
        if (values == null || values.Length < 1)
        {
            Debug.LogError(values + "Length < 1");
        }
        _maxIndex = values.Length - 1;
    }

    public T GetFromPool()
    {
        if (_pool.Count >  0)
            return _pool.Dequeue();
        else
        {
            if (_index > _maxIndex)
            {
                _index = 0;
            }
            return values[_index++];
        }
    }

    public void ReturnInPool(T value)
    {
        _pool.Enqueue(value);
    }
}
