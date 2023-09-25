using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : Entity
{
    Ship_Movement _movement;
    Ship_Attacks _attacks;
    Ship_Inputs _inputs;
    Ship_Collisions _collisions;
    public int speed;
    Rigidbody _rb;
    public Bullet _bulletPrefab;
    public int dashforce;

    [SerializeField] Controller _controller;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _attacks = new Ship_Attacks(_bulletPrefab , this);
        _inputs = new Ship_Inputs(_attacks);
        _movement = new Ship_Movement(speed, _rb , _inputs , dashforce , _controller);
        _collisions = new Ship_Collisions(this);

        _inputs.CompleteData(_movement);
        _inputs.BindKeys(KeyCode.LeftShift, new DashCommand());
    }
    

    // Update is called once per frame
    void Update()
    {
        _inputs.ArtificialUpdate();
    }

    private void FixedUpdate()
    {
        
        _movement.ArtificialUpdate();
    }

    private void OnCollisionEnter(Collision collision)
    {
        _collisions.ArtificialOnCollisionEnter(collision);
    }
    public override void TakeDmg(int dmg)
    {
        _life -= dmg;
    }

    public void Dash()
    {
        _movement.Dash();
    }
}
