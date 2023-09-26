using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_Movement
{
    Ship_Inputs _inputs;
    float _speed;
    Rigidbody _rb;
    float _dashforce;
    float _actualDashImpulse;
    Controller _controller;
    float _MultiplicadorDeVelocidad = 100;
    bool _canDash;
    float _dashCoolDown;
    float _dashCoolDownCounter;
    
    Vector3 _forceToApply;
    float _forceDamping = 1.2f;
    

    public Ship_Movement(float Speed, Rigidbody Rb, Ship_Inputs Inputs, float Dashforce, Controller controller, float DashCooldown)
    {
        _speed = Speed;
        _rb = Rb;
        _inputs = Inputs;
        _dashforce = Dashforce;
        _controller=controller;
        _actualDashImpulse = _dashforce;
        _canDash = true;
        _dashCoolDown = DashCooldown;
        _dashCoolDownCounter = DashCooldown;
    }

    public void ArtificialUpdate()
    {
        Move();
    }

    void Move()
    {

#if UNITY_STANDALONE

        _inputs.direction.x = Input.GetAxisRaw("Horizontal");
        _inputs.direction.z = Input.GetAxisRaw("Vertical");


        _rb.velocity = new Vector3(_inputs.direction.x, 0, _inputs.direction.z).normalized * (_speed + _actualDashImpulse) * _MultiplicadorDeVelocidad * Time.deltaTime;
        Dash();
        /*Vector3 PlayerInput = new Vector3(_inputs.direction.x, 0, _inputs.direction.z).normalized;
        Vector3 moveForce = PlayerInput * _speed;
        moveForce += _forceToApply;
        _forceToApply /= _forceDamping;
        if (Mathf.Abs(_forceToApply.x) <= 0.01f && Mathf.Abs(_forceToApply.z) <= 0.01f)
        {
            _forceToApply = Vector2.zero;
        }
        _rb.velocity = moveForce;*/
        // _rb.MovePosition(_rb.position +_inputs.direction * _speed * Time.deltaTime);
#endif

#if UNITY_ANDROID

        _rb.MovePosition(_rb.position + _controller.GetControllerDirection() * _speed * Time.deltaTime);
#endif
    }
    //Preguntar al de algoritmos si hay una forma mas prolija de hacer el dash
    public void ActivateDash()
    {
        if (_dashCoolDownCounter >= _dashCoolDown)
        {
            _canDash = true;
            _dashCoolDownCounter = 0;
            _actualDashImpulse = _dashforce;
        }
       
        
    }

    public void Dash()
    {
        if (_canDash)
        {
           

            _actualDashImpulse -= Mathf.Clamp(_actualDashImpulse, 0, Time.deltaTime * 40);
            //Debug.Log(_actualDashImpulse);
            if (_actualDashImpulse <= 0)
            {

                _canDash = false;
            }
        }
        else
        {
            if (_dashCoolDownCounter <= _dashCoolDown)
                _dashCoolDownCounter += Time.deltaTime;
            
            


        }
    }
}
