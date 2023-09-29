using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_Attacks 
{
    Ship _ship;
    Bullet _bullet;
    int _specialShootCounter;
    [SerializeField] int _specialShootCooldown;
    float _shootrate;
    float _shootrateCooldown;
    public bool isShooting;

    public Ship_Attacks(Bullet Bullet, Ship Ship, float shootrate)
    {
        _bullet = Bullet;

        _ship = Ship;
        _shootrate = shootrate;
        _shootrateCooldown = _shootrate;
    }

    public void ArtificialUpdate()
    {
        if (isShooting)
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        _shootrateCooldown += Time.deltaTime;
        if (_shootrateCooldown >= _shootrate)
        {
            Debug.Log("Disparo");
            var Bullet = BulletFactory.Instance.GetBulletFromPool(BulletFactory.BalasID.Player_BalaNormal);
            _shootrateCooldown = 0;
        }
        
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
