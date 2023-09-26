using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemyFactory : MonoBehaviour
{
    // Start is called before the first frame update
    public static NormalEnemyFactory Instance;
    BulletPool<EnemyGlobalScript> _SpawnerEnemyPool;

    [SerializeField] EnemyGlobalScript _EnemyPrefab;
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

        _SpawnerEnemyPool = new BulletPool<EnemyGlobalScript>(CreatorMethod, EnemyGlobalScript.EnemyTurnOn, EnemyGlobalScript.EnemyTurnOff, _initialAmount);

    }
    void Start()
    {

    }

    EnemyGlobalScript CreatorMethod()
    {
        return Instantiate(_EnemyPrefab);
    }

    public EnemyGlobalScript GetEnemyFromPool()
    {
        return _SpawnerEnemyPool.GetObject();
    }

    public void ReturnEnemyToPool(EnemyGlobalScript Obj)
    {
        _SpawnerEnemyPool.ReturnObject(Obj);
    }


}

