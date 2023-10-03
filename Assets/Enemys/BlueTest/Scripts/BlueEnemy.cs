using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BlueEnemy : EnemyGlobalScript
{
    [SerializeField] float _horizontalDistanceToMove;
    [SerializeField] float _pauseBetweenCycle;
    float _pauseBetweenTimer;
    float _cycleTimer = 1000;
    AnimationCurve _actualMovementFlowCurve;
    [SerializeField] AnimationCurve[] _movementsFlowCurve;
     float _distanceTraveled;
    Action _MoveSystem;
    Action _AttackSystem;

    Vector3 _initPosition;
    Vector3 _finalPosition;
    

    [HideInInspector] public float _shootrateCountdown;
    public float shootrate;
    float _actualSpeed;
    public float entryMaxSpeed;
    public float entrySpeedMultiplier;
    float _entrySpeedCounter;

    bool _changeDirection;
    // Start is called before the first frame update
    protected override void Start()
    {
        
        base.Start();
        ResetState();

       
    }

    public override void ResetState()
    {
        base.ResetState();
        _MoveSystem = MoveDown;
        _AttackSystem = delegate { };
        int chance = UnityEngine.Random.Range(0, 2);
        if (chance == 0)
        {
            _changeDirection = true;
        }
        else _changeDirection = false;
        int randomCurveChance = UnityEngine.Random.Range(0, _movementsFlowCurve.Length);
        _actualMovementFlowCurve = _movementsFlowCurve[randomCurveChance];
    }
    // Update is called once per frame
    protected override void Update()
    {
        _MoveSystem();
        _AttackSystem();
        if (Vector3.Distance(transform.position, GameManager.instance.LimiteEnemigosDerecha.position) <= _horizontalDistanceToMove )
        {
        }
    }
    void MoveSideToSide()
    {
        
        _pauseBetweenTimer += Time.deltaTime;
        if (_pauseBetweenTimer >= _pauseBetweenCycle)
        {
            

        }
        if (_cycleTimer >= _speed)
        {
            _initPosition = transform.position;
            if (transform.position.x >= GameManager.instance.LimiteEnemigosDerecha.position.x - GameManager.instance.LimiteEnemigosIzquierda.lossyScale.z / 2 - _horizontalDistanceToMove)
            {
                _changeDirection = true;

            }
            else if (GameManager.instance.LimiteEnemigosIzquierda.localPosition.x + GameManager.instance.LimiteEnemigosIzquierda.lossyScale.z / 2 >= transform.position.x - _horizontalDistanceToMove)
            {
                _changeDirection = false;

            }

            if (!_changeDirection)
            {
                _finalPosition = _initPosition + (Vector3.right * _horizontalDistanceToMove);
            }
            else
            {
                _finalPosition = _initPosition + (Vector3.left * _horizontalDistanceToMove);

            }
            _cycleTimer = 0;
            _pauseBetweenTimer = 0;
        }
        
        float percentage = _cycleTimer / _speed;
        if (_pauseBetweenTimer >= _pauseBetweenCycle)
        {
            _cycleTimer += Time.deltaTime;
            transform.position = Vector3.Lerp(_initPosition, _finalPosition, _actualMovementFlowCurve.Evaluate(percentage));

        }
    }

    void Shoot()
    {
        _shootrateCountdown += Time.deltaTime;
        if (_shootrateCountdown >= shootrate)
        {
            BlueEnemyBullet bullet = BulletFactory.Instance.GetBulletFromPool(BulletFactory.BalasID.Enemy_BalaBlueEnemy).GetComponent<BlueEnemyBullet>();
            bullet.gameObject.transform.position = transform.position - (Vector3.forward * transform.localScale.z);

            _shootrateCountdown = 0;

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

    void MoveDown()
    {
        _entrySpeedCounter += Time.deltaTime * entrySpeedMultiplier;
        _actualSpeed = Mathf.Clamp(_entrySpeedCounter, 0, entryMaxSpeed);
        //Debug.Log(_actualSpeed);
        transform.position += Vector3.back * _actualSpeed * Time.deltaTime;
    }

    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if (other.gameObject.layer == 9)
        {
            _actualSpeed = _speed;
            _MoveSystem = MoveSideToSide;
            _AttackSystem = Shoot;
        }
       
    }



}
