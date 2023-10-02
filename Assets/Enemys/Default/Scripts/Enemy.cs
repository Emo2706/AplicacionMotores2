using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : EnemyGlobalScript
{
    public float shootrate;
    float _actualSpeed;
    public float entryMaxSpeed;
    public float entrySpeedMultiplier;
    float _entrySpeedCounter;
    
    [HideInInspector] public float _shootrateCountdown;
    bool _changeDirection;
    // Start is called before the first frame update
    Action MoveSystem;
    Action AttackSystem;
   protected override void Start()
    {
        base.Start();
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

        if (Input.GetKeyDown(KeyCode.E))
        {
            CurrencyType Currency = CurrencyFactory.instance.GetCurrencyFromPool(CurrencyFactory.Currency_Type.NormalCurrency);
            Currency.gameObject.transform.position = transform.position;
        }

    }

    public override void DamageTaken(float DMGreceived)
    {
        base.DamageTaken(DMGreceived);
        if (_isDead)
        {
            NormalEnemyFactory.Instance.ReturnEnemyToPool(this, NormalEnemyFactory.EnemiesID.Enemy_Normal);
            CurrencyType CurrencyDrop = CurrencyFactory.instance.GetCurrencyFromPool(CurrencyFactory.Currency_Type.NormalCurrency);
            CurrencyDrop.gameObject.transform.position = gameObject.transform.position;
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
        if (other.gameObject.layer == 10)
        {
            _changeDirection = !_changeDirection;
        }
    }
    protected override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
       
    }

    void MoveDown()
    {
        _entrySpeedCounter += Time.deltaTime * entrySpeedMultiplier;
        _actualSpeed =  Mathf.Clamp(_entrySpeedCounter , 0, entryMaxSpeed);
        //Debug.Log(_actualSpeed);
        transform.position += Vector3.back * _actualSpeed * Time.deltaTime;
    }

    void MoveSideToSide()
    {
        if (_changeDirection)
        {
            transform.position += Vector3.right * _actualSpeed * Time.deltaTime;
        }
        else transform.position += Vector3.left * _actualSpeed * Time.deltaTime;

    }
}
