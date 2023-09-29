using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BulletPool<T>
{
    // Start is called before the first frame update

    Func<T> _factoryMethod;
    Action<T> _TurnOnCallback;
    Action<T> _TurnOffCallback;

    List<T> _currentStock;

    public BulletPool(Func<T> FactoryMethod, Action<T>TurnOnCallBack, Action<T> TurnOffCallBack , int initialAmount)
    {
        _currentStock = new List<T>();
        _factoryMethod = FactoryMethod;
        _TurnOffCallback = TurnOffCallBack;
        _TurnOnCallback = TurnOnCallBack;

        for (int i = 0; i < initialAmount; i++)
        {
            T newObj = _factoryMethod();
            _TurnOffCallback(newObj);
            _currentStock.Add(newObj);
        }
        

    }
    

    public T GetObject()
    {
        T result;

        if (_currentStock.Count == 0)
        {
            result = _factoryMethod();
        }
        else
        {
         
            result = _currentStock[0];
            _currentStock.RemoveAt(0);
        }
        _TurnOnCallback(result);

        return result;
    }

    public void ReturnObject(T obj)
    {
        _currentStock.Add(obj);
        _TurnOffCallback(obj);
       
    }
}
