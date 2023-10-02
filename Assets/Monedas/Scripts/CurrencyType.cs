using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CurrencyType : MonoBehaviour
{
    

    public int value;
    [SerializeField] protected float _speed;
    [SerializeField] protected int _speedrotatino;

    [SerializeField] protected float _fallingIncreaseSpeed;
    [SerializeField] protected float _fallingIncreaseSpeedMultiplicator;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void TurnOn(CurrencyType Currency)
    {
        Currency.ResetState();
        Currency.gameObject.SetActive(true);
    }
    public static void TurnOff(CurrencyType Currency)
    {
        Currency.gameObject.SetActive(false);
    }
    protected virtual void ResetState()
    {

    }

}
