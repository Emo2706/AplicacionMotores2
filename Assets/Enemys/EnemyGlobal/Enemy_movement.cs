using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_movement 
{
    Ship _ship;
    Vector3 _direction;
    EnemyGlobalScript _enemies;
    Rigidbody _rb;
    int _speed;
    Transform _transform;
    float _speedRotation = 55f;

    public Enemy_movement(Ship ship , EnemyGlobalScript enemies , Rigidbody rb , int speed , Transform transform)
    {
        _ship = ship;
        _enemies = enemies;
        _rb = rb;
        _speed = speed;
        _transform = transform;
    }

    

    public void ArtificialUpdate()
    {
        Move();
    }

    void Move()
    {
        _transform.forward = Vector3.Lerp(_transform.position ,_ship.transform.position  , _speedRotation);
       
    }

    
}
