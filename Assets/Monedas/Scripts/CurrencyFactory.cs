using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CurrencyFactory : MonoBehaviour
{
    public enum Currency_Type
    {
        NormalCurrency,
        PremiumGemCurrency,
    }
    public static CurrencyFactory instance;
    

    public CurrencyType[] _currencyPrefabs;
    [SerializeField] int _coinInitialAmount, _gemsInitialAmount;

    public Dictionary<Currency_Type, BulletPool<CurrencyType>> _CurrencyPools = new();
    BulletPool<CurrencyType> _CoinPool;
    BulletPool<CurrencyType> _PremiumGemPool;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        _CoinPool = new BulletPool<CurrencyType>(CoinCreatorMethod, CurrencyType.TurnOn, CurrencyType.TurnOff, _coinInitialAmount);
        _PremiumGemPool = new BulletPool<CurrencyType>(PremiumGemCreatorMethod, CurrencyType.TurnOn, CurrencyType.TurnOff, _gemsInitialAmount);

      

        _CurrencyPools.Add(Currency_Type.NormalCurrency, _CoinPool);
        _CurrencyPools.Add(Currency_Type.PremiumGemCurrency, _PremiumGemPool);


    }

    CurrencyType CoinCreatorMethod()
    {
        return Instantiate(_currencyPrefabs[0]);
    }
    CurrencyType PremiumGemCreatorMethod()
    {
        return Instantiate(_currencyPrefabs[1]);
    }

    public CurrencyType GetCurrencyFromPool(Currency_Type currencyTypeToGet)
    {
        /*if (_CurrencyPools.ContainsKey(currencyTypeToGet))
        {
            return _CurrencyPools[currencyTypeToGet]();
        }*/

        if ((_CurrencyPools.ContainsKey(currencyTypeToGet)))
        {
            return _CurrencyPools[currencyTypeToGet].GetObject();
        } 

        return default;
    }

    public void ReturnCurrencyToPoll(Currency_Type currencyTypeToGet, CurrencyType obj)
    {
        if ((_CurrencyPools.ContainsKey(currencyTypeToGet)))
        {
            _CurrencyPools[currencyTypeToGet].ReturnObject(obj);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            GetCurrencyFromPool(CurrencyFactory.Currency_Type.NormalCurrency);
        }
    }
}
