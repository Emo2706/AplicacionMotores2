using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyGlobalScript : Entity
{
    Enemy_movement _enemyMovement;
    Enemy_attacks _enemyAttacks;
    
    Rigidbody _rb;

    [SerializeField] Ship _ship;

    [SerializeField] int _speed;

    [SerializeField] EnemyBullet _bullet;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _enemyMovement = new Enemy_movement(_ship , this , _rb , _speed , transform);
        _enemyAttacks = new Enemy_attacks(_bullet);
       
    }

    // Update is called once per frame
   protected virtual void Update()
    {
           _enemyAttacks.ArtificialUpdate();
    }

    private void FixedUpdate()
    {
        _enemyMovement.ArtificialUpdate();
    }
   

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Bullet>(out Bullet bullet))
        {
            DamageTaken(bullet.dmg);
        }
    }

    public virtual void ResetState()
    {

    }

    public static void EnemyTurnOn(EnemyGlobalScript enemy)
    {
        enemy.ResetState();
        enemy.gameObject.SetActive(true);
    }
    public static void EnemyTurnOff(EnemyGlobalScript enemy)
    {
        enemy.ResetState();
        enemy.gameObject.SetActive(false);
    }

    


}
