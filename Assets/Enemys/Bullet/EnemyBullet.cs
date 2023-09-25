using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int speedBullet;
    public Vector3 bulletDirection;
    Rigidbody _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }



    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        _rb.position += bulletDirection.normalized * speedBullet * Time.deltaTime;

    }
}
