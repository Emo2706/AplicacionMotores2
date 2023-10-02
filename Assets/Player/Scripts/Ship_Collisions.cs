using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Ship_Collisions 
{
    Ship _ship;
    Action<float> Damagetaken;
    
    public Ship_Collisions(Ship Ship, Action<float> DMGtaken)
    {
        _ship = Ship;
        Damagetaken = DMGtaken;
    }
    public void ArtificialOnCollisionEnter(Collision collision)
    {
        
    }

    public void ArtificialOnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<EnemyBullet>(out EnemyBullet EnemyBullet))
        {
            Damagetaken(EnemyBullet.dmg);
            
        }
        if (other.TryGetComponent<Moneda>(out Moneda moneda))
        {
            EventManager.TriggerEvent(EventManager.EventsType.Event_GrabCoin, moneda.value);
            CurrencyFactory.instance.ReturnCurrencyToPoll(CurrencyFactory.Currency_Type.NormalCurrency, moneda);
        }
    }
    
}
