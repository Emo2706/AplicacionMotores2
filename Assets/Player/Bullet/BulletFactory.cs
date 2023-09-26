using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFactory : MonoBehaviour
{
    // Start is called before the first frame update
    public static BulletFactory Instance;
    BulletPool<Bullet> _playerBulletPool;

   [SerializeField] Bullet _bulletPrefab;
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
        
        _playerBulletPool = new BulletPool<Bullet>(CreatorMethod, Bullet.BulletTurnOn, Bullet.BulletTurnoff, _initialAmount);

    }
    void Start()
    {

    }

    Bullet CreatorMethod()
    {
        return Instantiate(_bulletPrefab);
    }

    public Bullet GetBulletFromPool()
    {
        return _playerBulletPool.GetObject();
    }

    public void ReturnBulletToPull(Bullet Obj)
    {
        _playerBulletPool.ReturnObject(Obj);
    }

   
}
