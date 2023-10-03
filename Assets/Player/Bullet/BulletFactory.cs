using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFactory : MonoBehaviour
{
    // Start is called before the first frame update
    public static BulletFactory Instance;
    BulletPool<Bullet> _playerBulletPool;
    BulletPool<Bullet> _EnemyBulletPool;
    BulletPool<Bullet> _BlueEnemyBulletPool;

   [SerializeField] Bullet[] _bulletPrefabs;
    [SerializeField] int _initialAmount;

    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
        }
        //Creo ambas pool, pero en cada una cambio el metodo de creacion por el correspondiente
        _playerBulletPool = new BulletPool<Bullet>(CreatorMethodNormalPlayerBullet, Bullet.BulletTurnOn, Bullet.BulletTurnoff, _initialAmount);
        _EnemyBulletPool = new BulletPool<Bullet>(CreatorMethodNormalEnemyBullet, Bullet.BulletTurnOn, Bullet.BulletTurnoff, _initialAmount);
        _BlueEnemyBulletPool = new BulletPool<Bullet>(CreatorMethodBlueEnemyBullet, Bullet.BulletTurnOn, Bullet.BulletTurnoff, _initialAmount);
    }

    Bullet CreatorMethodNormalPlayerBullet()
    {
        return Instantiate(_bulletPrefabs[BalasID.Player_BalaNormal]);
    }

    Bullet CreatorMethodNormalEnemyBullet()
    {
        return Instantiate(_bulletPrefabs[BalasID.Enemy_BalaNormal]);
    }

    Bullet CreatorMethodBlueEnemyBullet()
    {
        return Instantiate(_bulletPrefabs[BalasID.Enemy_BalaBlueEnemy]);
    }

    public Bullet GetBulletFromPool(int ID)
    {
        if (ID == BalasID.Player_BalaNormal)
        {
            return _playerBulletPool.GetObject();
        }
        else if (ID == BalasID.Enemy_BalaNormal)
        {
            return _EnemyBulletPool.GetObject();
        }
        else if (ID == BalasID.Enemy_BalaBlueEnemy)
        {
            return _BlueEnemyBulletPool.GetObject();
        }
        else return default;


    }

    public void ReturnBulletToPull(Bullet Obj, int ID)
    {
        if (ID == BalasID.Player_BalaNormal)
        {
            _playerBulletPool.ReturnObject(Obj);
        }
        else if (ID == BalasID.Enemy_BalaNormal)
        {
             _EnemyBulletPool.ReturnObject(Obj);
        }
        else if (ID == BalasID.Enemy_BalaBlueEnemy)
        {
            _BlueEnemyBulletPool.ReturnObject(Obj);
        }
       
        
    }

    public static class BalasID
    {
        public const int Player_BalaNormal = 0;
        public const int Enemy_BalaNormal = 1;
        public const int Enemy_BalaBlueEnemy = 2;
        
    }


}
