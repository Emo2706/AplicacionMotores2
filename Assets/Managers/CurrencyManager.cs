using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager instance;
    public int normal_currency;
    public int Premium_currency;
    

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
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddNormalCurrency(int Amount)
    {
        normal_currency += Amount;
        UIManager.instance.ChangeNormalCurrencyDisplay(normal_currency);
    }
    public bool BuyWithNormalCurrency(int Amount)
    {
        if (Amount <= normal_currency)
        {
            normal_currency -= Amount;
            UIManager.instance.ChangeNormalCurrencyDisplay(normal_currency);
            return true;
        }
        else return false;
        

    }

    public void AddPremiumCurrency(int Amount)
    {
        Premium_currency += Amount;
    }

    public bool BuyWithPremiumCurrency(int Amount)
    {
        if (Amount <= Premium_currency)
        {
            Premium_currency -= Amount;
            return true;
        }
        else return false;
    }

}
