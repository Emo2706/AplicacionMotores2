using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda : CurrencyType
{
    Vector3 _dirToPlayer;
    [SerializeField] float _attractDistance;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotate();
        AttractToPlayer();

    }

    void Move()
    {
        if (AttractToPlayer())
        {
            transform.position += _dirToPlayer.normalized * Time.deltaTime * _speed;
        }
        else transform.position += Vector3.back * Time.deltaTime * _speed;
        
        _fallingIncreaseSpeedMultiplicator += Time.deltaTime;
        _speed += Time.deltaTime * _fallingIncreaseSpeed * _fallingIncreaseSpeedMultiplicator;
    }

    void Rotate()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * _speedrotatino);
       
    }

    bool AttractToPlayer()
    {
        if (Vector3.Distance(transform.position, GameManager.instance.player.gameObject.transform.position) <= _attractDistance)
        {
            _dirToPlayer = GameManager.instance.player.gameObject.transform.position - transform.position;
            return true;
        }
        else _dirToPlayer = Vector3.zero;
        return false;


    }

    

    
}
