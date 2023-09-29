using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemyFactory : MonoBehaviour
{
    // Start is called before the first frame update
    public static NormalEnemyFactory Instance;
    BulletPool<EnemyGlobalScript> _SpawnerEnemyPool;
    BulletPool<EnemyGlobalScript> _SpawnerBlueEnemyPool;

    [SerializeField] public EnemyGlobalScript[] _EnemyPrefabs;
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
        //PREGUNTARLE AL DE MODELOS SI ESTA BIEN LA WEA DE LOS RETURN BULLETS Y ESO
        _SpawnerEnemyPool = new BulletPool<EnemyGlobalScript>(NormalEnemyCreatorMethod, EnemyGlobalScript.EnemyTurnOn, EnemyGlobalScript.EnemyTurnOff, _initialAmount);
        _SpawnerBlueEnemyPool = new BulletPool<EnemyGlobalScript>(BlueEnemyCreatorMethod, EnemyGlobalScript.EnemyTurnOn, EnemyGlobalScript.EnemyTurnOff, _initialAmount);

    }
    void Start()
    {

    }

    EnemyGlobalScript NormalEnemyCreatorMethod()
    {
        return Instantiate(_EnemyPrefabs[EnemiesID.Enemy_Normal]);
    }
    EnemyGlobalScript BlueEnemyCreatorMethod()
    {
        return Instantiate(_EnemyPrefabs[EnemiesID.Enemy_Blue]);
    }

    public EnemyGlobalScript GetEnemyFromPool(int ID)
    {
        if (ID == EnemiesID.Enemy_Normal)
        {
            return _SpawnerEnemyPool.GetObject();
        }
        else if (ID == EnemiesID.Enemy_Blue)
        {
            return _SpawnerBlueEnemyPool.GetObject();
        }
        else return default;
        
    }

    public void ReturnEnemyToPool(EnemyGlobalScript Obj, int ID)
    {
        if (ID == EnemiesID.Enemy_Normal)
        {
            _SpawnerEnemyPool.ReturnObject(Obj);
        }
        else if (ID == EnemiesID.Enemy_Blue)
        {
            _SpawnerBlueEnemyPool.ReturnObject(Obj);
        }
       
       
    }

    public static class EnemiesID
    {
        public const int Enemy_Normal = 0;
        public const int Enemy_Blue = 1;

    }

}

