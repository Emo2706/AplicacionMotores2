using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : EnemyGlobalScript
{
    public float shootrate;
    float _actualSpeed;
    [HideInInspector] public float _shootrateCountdown;
    bool _changeDirection;
    // Start is called before the first frame update
    Action MoveSystem;
    Action AttackSystem;
   protected override void Start()
    {
        base.Start();
        _speed /= 10;
    }

    public override void ResetState()
    {
        base.ResetState();
        _shootrateCountdown = UnityEngine.Random.Range(0, shootrate);
        MoveSystem = MoveDown;
        AttackSystem = delegate { };
            
        _actualSpeed = 0;
        
    }


    // Update is called once per frame
    protected override void Update()
    {
        //base.Update();
        AttackSystem();
        MoveSystem();

    }

    public override void DamageTaken(float DMGreceived)
    {
        base.DamageTaken(DMGreceived);
        if (_isDead)
        {
            NormalEnemyFactory.Instance.ReturnEnemyToPool(this, NormalEnemyFactory.EnemiesID.Enemy_Normal);
        }
    }

    void Shoot()
    {
        _shootrateCountdown += Time.deltaTime;
        if (_shootrateCountdown >= shootrate)
        {
            NormalEnemyBullet bullet = BulletFactory.Instance.GetBulletFromPool(BulletFactory.BalasID.Enemy_BalaNormal).GetComponent<NormalEnemyBullet>();
            bullet.gameObject.transform.position = transform.position - (Vector3.forward * transform.localScale.z);

            _shootrateCountdown = 0;

        }
    }
    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if (other.gameObject.layer == 9)
        {
            _actualSpeed = _speed;
            MoveSystem = MoveSideToSide;
            AttackSystem = Shoot;
        }
    }
    protected override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
        if (collision.gameObject.layer == 10)
        {
            _changeDirection = !_changeDirection;
        }
    }

    void MoveDown()
    {
        _actualSpeed = Mathf.Clamp(_actualSpeed + (Time.deltaTime), 0, _speed)/1.3f;
        transform.position += Vector3.back * _actualSpeed;
    }

    void MoveSideToSide()
    {
        if (_changeDirection)
        {
            transform.position += Vector3.right * _actualSpeed;
        }
        else transform.position += Vector3.left * _actualSpeed;

    }
}
