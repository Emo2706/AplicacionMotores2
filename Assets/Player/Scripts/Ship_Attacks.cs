using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_Attacks 
{
    Ship _ship;
    Bullet _bullet;
    int _specialShootCounter;
    [SerializeField] int _specialShootCooldown;

    public Ship_Attacks(Bullet Bullet, Ship Ship)
    {
        _bullet = Bullet;

        _ship = Ship;
    }

    public void Shoot()
    {

    }

    public void SpecialShoot()
    {
        if (_specialShootCounter==_specialShootCooldown)
        {
            _specialShootCounter = 0;
            _ship.StartCoroutine(SpecialShootCharge());

        }
    }

    IEnumerator SpecialShootCharge()
    {
        while (_specialShootCounter<_specialShootCooldown)
        {
            _specialShootCounter++;
        }

        yield return new WaitForSeconds(_specialShootCooldown);
    }
}
