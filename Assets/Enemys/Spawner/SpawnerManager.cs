using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{

    public static SpawnerManager instance;
    [HideInInspector] public float spawnRate;
    float _spawnRateCounter;

    public float speedMovement;
    bool _changeDirection;
    [SerializeField] RoundsData[] Rounds;
    //[HideInInspector] public List<EnemyGlobalScript> enemiesAlive;
    public List<EnemyGlobalScript> enemiesAliveTest;
    [HideInInspector] public int enemiesAlive;
    //[HideInInspector] public int enemiesKilled;
    int _enemySpawned;
    int _activeRound;
    public Dictionary<EnemyGlobalScript, int> tipo_de_enemigo;

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
        
        spawnRate = Rounds[0].DefaultTimeBetweenEnenmySpawn;
        tipo_de_enemigo = new Dictionary<EnemyGlobalScript, int>()
        {
            {NormalEnemyFactory.Instance._EnemyPrefabs[NormalEnemyFactory.EnemiesID.Enemy_Normal], NormalEnemyFactory.EnemiesID.Enemy_Normal},
            {NormalEnemyFactory.Instance._EnemyPrefabs[NormalEnemyFactory.EnemiesID.Enemy_Blue], NormalEnemyFactory.EnemiesID.Enemy_Blue}
            
        };
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            Debug.Log(enemiesAlive);
            Debug.Log(_activeRound);
        }
        SpawnEnemies();
        Movement();

        if (Input.GetKeyDown(KeyCode.T))
        {
            //enemiesAliveTest.RemoveAt(0);
            NormalEnemyFactory.Instance.ReturnEnemyToPool(enemiesAliveTest[0], 1);
            enemiesAliveTest.RemoveAt(0);
            

           
            /*enemiesAlive.RemoveAt(0);
            Debug.Log(enemiesAlive.Count);*/


        }
        
            
    }

    void SpawnEnemies()
    {
        //if (enemiesAlive < Rounds[_activeRound].MaxAmountofEnemiesAtTime)
        if (enemiesAlive < Rounds[_activeRound].MaxAmountofEnemiesAtTime)
        {
            if (_enemySpawned < Rounds[_activeRound].EnemiesSpawnOrder.Length)
            {
                _spawnRateCounter += Time.deltaTime;
                if (_spawnRateCounter >= spawnRate)
                {

                    var LastEnemySpawned = NormalEnemyFactory.Instance.GetEnemyFromPool(tipo_de_enemigo[Rounds[_activeRound].EnemiesSpawnOrder[_enemySpawned]]);
                    LastEnemySpawned.enemyCodeOnScene = _enemySpawned;
                    enemiesAliveTest.Add(LastEnemySpawned);
                    //enemiesAlive.Add(LastEnemySpawned);
                    _enemySpawned++;
                    enemiesAlive++;
                    _spawnRateCounter = 0;
                }
            }
           
        }
    }

   
    public void EnemyKilled()
    {
        enemiesAlive = Mathf.Clamp(enemiesAlive -1, 0, 1000);
        //enemiesAlive.RemoveAt(enemyCode);
        if (_enemySpawned >= Rounds[_activeRound].EnemiesSpawnOrder.Length && enemiesAlive <= 0)
        {
            if (_activeRound == Rounds.Length -1)
            {
                GameManager.instance.NivelCompletado();
            }
            else
            {
                _activeRound = Mathf.Clamp(_activeRound + 1, 0, Rounds.Length -1);
                _enemySpawned = 0;
                //enemiesAlive.Clear();
                _spawnRateCounter = 0;
                spawnRate = Rounds[_activeRound].DefaultTimeBetweenEnenmySpawn;
            }
           
            
        }
    }

   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            _changeDirection = !_changeDirection;
        }
    }

    void Movement()
    {
        if (_changeDirection)
        {
            transform.position += Vector3.right * speedMovement;
        }
        else transform.position += Vector3.left * speedMovement;
    }
}
