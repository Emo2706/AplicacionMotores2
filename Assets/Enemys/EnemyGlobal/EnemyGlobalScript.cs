using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class EnemyGlobalScript : Entity
{
    Enemy_movement _enemyMovement;
    Enemy_attacks _enemyAttacks;
    
    Rigidbody _rb;
    [SerializeField] Canvas _EnemyCanvasPrefab;
    protected Canvas _canvasEnemy;
    protected Slider _sliderHealthBar;
    [SerializeField] Vector3 _canvasEnemyOffset;

    [SerializeField] Ship _ship;

    [SerializeField] protected float _speed;

    [SerializeField] EnemyBullet _bullet;

    [HideInInspector] public int enemyCodeOnScene;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        _canvasEnemy = Instantiate(_EnemyCanvasPrefab, transform.position + _canvasEnemyOffset, transform.rotation);
        _canvasEnemy.transform.SetParent(transform);
        _sliderHealthBar = _canvasEnemy.GetComponentInChildren<Slider>();

        /*_rb = GetComponent<Rigidbody>();
        _enemyMovement = new Enemy_movement(_ship , this , _rb , _speed , transform);
        _enemyAttacks = new Enemy_attacks(_bullet);*/
    }





    // Update is called once per frame
    protected virtual void Update()
    {
           _enemyAttacks.ArtificialUpdate();
    }

    private void FixedUpdate()
    {
        //_enemyMovement.ArtificialUpdate();
    }
   

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Bullet>(out Bullet Bullet) && other.GetComponent<EnemyBullet>() == null)
        {
            
            DamageTaken(Bullet.dmg);
        }
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        
    }

    public virtual void ResetState()
    {
        
        _canvasEnemy?.gameObject.SetActive(false);

        life = maxLife;
        transform.position = SpawnerManager.instance.gameObject.transform.position;
    }

    public static void EnemyTurnOn(EnemyGlobalScript enemy)
    {
        enemy.ResetState();
        enemy.gameObject.SetActive(true);
    }
    public static void EnemyTurnOff(EnemyGlobalScript enemy)
    {
        
        SpawnerManager.instance.EnemyKilled();
       
        enemy.gameObject.SetActive(false);
        //CurrencyFactory.instance.GetCurrencyFromPool(CurrencyFactory.Currency_Type.NormalCurrency);
       

    }

    


}
