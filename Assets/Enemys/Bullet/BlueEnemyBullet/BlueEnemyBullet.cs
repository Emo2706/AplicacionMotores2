using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueEnemyBullet : EnemyBullet
{
    float _speedMultiplicator;
    [SerializeField] float _speedMultiplicator2;
    [SerializeField] float _timeBeforeSpeedingUp;
    public override void Move()
    {
        if (_speedMultiplicator <= _timeBeforeSpeedingUp)
        {
            _speedMultiplicator += Time.deltaTime;

        }
        else _speedMultiplicator += Time.deltaTime * 5;

        speedBullet += Time.deltaTime * _speedMultiplicator * _speedMultiplicator2;
         transform.position += bulletDirection * speedBullet * Time.deltaTime;
    }
    public override void Reset()
    {
        speedBullet = 0;
        _speedMultiplicator = 0;
        bulletDirection = new Vector3(Random.Range(-1f, 1f), 0, -1);
        float rotY = Mathf.Atan2(bulletDirection.x, bulletDirection.z) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, rotY, 0);
    }
    // Start is called before the first frame update

    public override void CheckIfIsOutOfBounds()
    {
        
        if (transform.position.z <= GameManager.instance.LimiteBalasEnZNegativo.position.z)
        {
            BulletFactory.Instance.ReturnBulletToPull(this, BulletFactory.BalasID.Enemy_BalaBlueEnemy);
        }
    }



    // Update is called once per frame

}
