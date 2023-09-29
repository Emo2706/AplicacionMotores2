using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Shop : MonoBehaviour
{
    
    public static Shop instance;
    public DatosDeCompra[] estadisticas;
    public int IdElegido;
    public Action<int> CompraItem;

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
        CompraItem += SubePrecio;

        for (int i = 0; i < estadisticas.Length; i++)
        {
            
            estadisticas[i].precioActual = estadisticas[i].OrdenDePrecio[estadisticas[i].CantComprada];

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuyItem()
    {
        if (estadisticas[IdElegido].PremiumCurrency == false)
        {
            if (CurrencyManager.instance.BuyWithNormalCurrency(estadisticas[IdElegido].precioActual))
            {
                if (estadisticas[IdElegido].OrdenDePrecio.Length - 1 > estadisticas[IdElegido].CantComprada)
                {
                    CompraItem(IdElegido);
                    Debug.Log(estadisticas[IdElegido].CantComprada);
                }
                else Debug.Log("Se alcanzó la mejora máxima");
                //Por ahora aunque llegues a la mejora maxima, si le das comprar, se te gasta guita igual, esto es por el Buy with normal currency. Se puede reformular para que buywithnormal currency este dentro del action comprar, o simplemente despues se hace que el botón deje de ser interactuable

            }
            else Debug.Log("No hay guita pe");
        }
        else
        {
            if (CurrencyManager.instance.BuyWithPremiumCurrency(estadisticas[IdElegido].precioActual))
            {
                Debug.Log("Se compro " + estadisticas[IdElegido].estadistica + " por " + estadisticas[IdElegido].precioActual + " de gemas");

            }
            else Debug.Log("No hay gemas pe");
        }
        
    }

    void SubePrecio(int ID)
    {

        
        
            estadisticas[ID].CantComprada++;
            estadisticas[ID].precioActual = estadisticas[ID].OrdenDePrecio[estadisticas[ID].CantComprada];
            Debug.Log("El precio ahora es de " + estadisticas[ID].OrdenDePrecio[estadisticas[ID].CantComprada]);


       
      
           
        

    }

    

    
   
}
