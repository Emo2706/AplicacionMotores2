using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_Inputs 
{
    Ship_Attacks _attacks;
    Ship_Movement _movement;
    public Vector3 direction;

    Dictionary<KeyCode, CommandInputs> _inputsDictionary;


    public Ship_Inputs(Ship_Attacks Attacks)
    {
        _attacks = Attacks;

        _inputsDictionary = new Dictionary<KeyCode, CommandInputs>();
       
    }

    public void BindKeys(KeyCode key , CommandInputs command)
    {
        _inputsDictionary[key] = command;
    }

    public CommandInputs Inputs()
    {
        foreach (var pair in _inputsDictionary)
        {
            if (Input.GetKeyDown(pair.Key))
            {
                return pair.Value;
            }

        }
            return null;
    }

    public void CompleteData(Ship_Movement Movement)
    {
        _movement = Movement;
    }

    public void ArtificialUpdate()
    {
        InputListener();
    }

    void InputListener()
    {

    #if UNITY_STANDALONE
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.z = Input.GetAxisRaw("Vertical");

        if (Input.GetMouseButton(0))
        {
            //_attacks.Shoot();
        }

        if (Input.GetMouseButton(1))
        {
            _attacks.SpecialShoot();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _movement.Dash();
        }

    #endif
    
    }
    
}
