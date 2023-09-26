using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : EnemyGlobalScript
{
    // Start is called before the first frame update
   protected override void Start()
    {
        base.Start();
    }

    

    // Update is called once per frame
  protected override void Update()
    {
        base.Update();
    }

    public override void DamageTaken(float DMGreceived)
    {
        base.DamageTaken(DMGreceived);
        if (_isDead)
        {
            NormalEnemyFactory.Instance.ReturnEnemyToPool(this);
        }
    }
}
