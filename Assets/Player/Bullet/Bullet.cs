using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    public float speedBullet;
    public Vector3 bulletDirection;
    float _divisor_de_velocidad = 10;
    public float dmg;
    
    public virtual void Start()
    {
       // _rb = GetComponent<Rigidbody>();
    }

   



    private void FixedUpdate()
    {
        Move();
    }
    protected virtual void Update()
    {
        CheckIfIsOutOfBounds();
    }

    public virtual void Move()
    {
        
        transform.position += bulletDirection * speedBullet / _divisor_de_velocidad ;

    }

    public virtual void Reset()
    {
        transform.position = GameManager.instance.player.transform.position + Vector3.forward * 1;
    }

    public static void BulletTurnOn(Bullet B)
    {
        B.Reset();

        B.gameObject.SetActive(true);
    }
    public static void BulletTurnoff(Bullet B)
    {
        B.gameObject.SetActive(false);
    }

    public virtual void CheckIfIsOutOfBounds()
    {
        if (transform.position.z >= GameManager.instance.LimiteBalasEnZ.position.z)
        {
            BulletFactory.Instance.ReturnBulletToPull(this, BulletFactory.BalasID.Player_BalaNormal);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        BulletFactory.Instance.ReturnBulletToPull(this, BulletFactory.BalasID.Player_BalaNormal);
    }
}
