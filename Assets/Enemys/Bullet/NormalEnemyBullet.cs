using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemyBullet : EnemyBullet
{
    // Start is called before the first frame update
    public override void Reset()
    {
       bulletDirection = new Vector3(Random.Range(-1f, 1f), 0, -1);
        
    }

    // Update is called once per frame
    
   
}
