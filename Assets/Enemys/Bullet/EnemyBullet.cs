using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Bullet
{
    
    // Start is called before the first frame update
   


    private void FixedUpdate()
    {
        Move();
    }

    public override void CheckIfIsOutOfBounds()
    {
        if (transform.position.z <= GameManager.instance.LimiteBalasEnZNegativo.position.z)
        {
            BulletFactory.Instance.ReturnBulletToPull(this, BulletFactory.BalasID.Enemy_BalaNormal);
        }
    }


}
