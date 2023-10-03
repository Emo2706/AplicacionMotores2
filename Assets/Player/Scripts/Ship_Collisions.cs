using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Ship_Collisions 
{
    Ship _ship;
   
    
    public Ship_Collisions(Ship Ship)
    {
        _ship = Ship;
        
    }
    public void ArtificialOnCollisionEnter(Collision collision)
    {
        
    }

    public void ArtificialOnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<EnemyBullet>(out EnemyBullet EnemyBullet))
        {
            
            EventManager.TriggerEvent(EventManager.EventsType.Event_PlayerTakesDmg, EnemyBullet.dmg, _ship.life);

            
        }
        if (other.TryGetComponent<Moneda>(out Moneda moneda))
        {
            EventManager.TriggerEvent(EventManager.EventsType.Event_GrabCoin, moneda.value);
            CurrencyFactory.instance.ReturnCurrencyToPoll(CurrencyFactory.Currency_Type.NormalCurrency, moneda);
        }
    }
    
}
