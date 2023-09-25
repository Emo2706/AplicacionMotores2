using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_Movement
{
    Ship_Inputs _inputs;
    int _speed;
    Rigidbody _rb;
    int _dashforce;
    Controller _controller;


    public Ship_Movement(int Speed, Rigidbody Rb, Ship_Inputs Inputs, int Dashforce, Controller controller)
    {
        _speed = Speed;
        _rb = Rb;
        _inputs = Inputs;
        _dashforce = Dashforce;
        _controller=controller;
    }

    public void ArtificialUpdate()
    {
        Move();
    }

    void Move()
    {

#if UNITY_STANDALONE

        _inputs.direction.x = Input.GetAxis("Horizontal");
        _inputs.direction.z = Input.GetAxis("Vertical");

        _rb.MovePosition(_rb.position +_inputs.direction * _speed * Time.deltaTime);
#endif

#if UNITY_ANDROID

        _rb.MovePosition(_rb.position + _controller.GetControllerDirection() * _speed * Time.deltaTime);
#endif
    }

    public void Dash()
    {
        _rb.AddForce(_inputs.direction.normalized * _dashforce, ForceMode.Impulse);
        

    }
}
