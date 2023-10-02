using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda : CurrencyType
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotate();

    }

    void Move()
    {
        transform.position += Vector3.back * Time.deltaTime * _speed;
        _fallingIncreaseSpeedMultiplicator += Time.deltaTime;
        _speed += Time.deltaTime * _fallingIncreaseSpeed * _fallingIncreaseSpeedMultiplicator;
    }

    void Rotate()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * _speedrotatino);
       
    }

    
}
