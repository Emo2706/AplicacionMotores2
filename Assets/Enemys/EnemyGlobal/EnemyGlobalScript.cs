using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyGlobalScript : Entity
{
    Enemy_movement _enemyMovement;
    Enemy_attacks _enemyAttacks;
    Enemy_collisions _enemyCollisions;
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
        _enemyCollisions = new Enemy_collisions();
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

    private void OnCollisionEnter(Collision collision)
    {
        _enemyCollisions.ArtificialOnCollisionEnter(collision);
    }

    public override void TakeDmg(int dmg)
    {
        _life -= dmg;
    }
}
