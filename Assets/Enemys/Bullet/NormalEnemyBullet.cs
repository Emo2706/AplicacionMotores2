using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemyBullet : EnemyBullet
{
    // Start is called before the first frame update
    public override void Reset()
    {
       bulletDirection = new Vector3(Random.Range(-1f, 1f), 0, -1);
       float rotY = Mathf.Atan2(bulletDirection.x, bulletDirection.z) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, rotY, 0);



    }

    // Update is called once per frame
    
   
}
