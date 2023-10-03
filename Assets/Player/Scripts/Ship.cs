using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : Entity
{
    Ship_Movement _movement;
    Ship_Attacks _attacks;
    Ship_Inputs _inputs;
    Ship_Collisions _collisions;
    public float speed;
    Rigidbody _rb;
    public Bullet _bulletPrefab;
    public float dashforce;
    [SerializeField] float _dashCooldown;
    [SerializeField] float shootrate;

    [SerializeField] Controller _controller;
    

    private void Awake()
    {
        maxLife = PlayerStatsManager.instance.maxlife;
        speed = PlayerStatsManager.instance.speed;
        shootrate = PlayerStatsManager.instance.shootrate;
        _dashCooldown = PlayerStatsManager.instance.dashcooldown;
        _rb = GetComponent<Rigidbody>();
        _attacks = new Ship_Attacks(_bulletPrefab , this, shootrate);
        _inputs = new Ship_Inputs(_attacks);
        _movement = new Ship_Movement(speed, _rb , _inputs , dashforce , _controller,_dashCooldown);
        _collisions = new Ship_Collisions(this);

        _inputs.CompleteData(_movement);
        _inputs.BindKeys(KeyCode.LeftShift, new DashCommand());
    }
    protected override void Start()
    {
        base.Start();
        EventManager.SubscribeToEvent(EventManager.EventsType.Event_PlayerTakesDmg, PlayerReceivesDamage);

    }

    


    // Update is called once per frame
    void Update()
    {
        _inputs.ArtificialUpdate();
        _attacks.ArtificialUpdate();
    }

    private void FixedUpdate()
    {
        
        _movement.ArtificialUpdate();
    }

    private void OnCollisionEnter(Collision collision)
    {
        _collisions.ArtificialOnCollisionEnter(collision);
    }

    private void OnTriggerEnter(Collider other)
    {
        _collisions.ArtificialOnTriggerEnter(other);
    }

    public override void DamageTaken(float DMGreceived)
    {
        base.DamageTaken(DMGreceived);
        Debug.Log(life);
    }
    void PlayerReceivesDamage(params object[] parameters)
    {
        float dmg = (float)parameters[0];
        DamageTaken(dmg);
    }


    public void Shoot()
    {
        _attacks.isShooting = true;
    }
    public void StopsShoot()
    {
        _attacks.isShooting = false;
    }

    public void ActivateDash()
    {
        _movement.ActivateDash();
    }
}
