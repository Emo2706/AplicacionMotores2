using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PY_NormalBullet : Bullet
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        dmg = PlayerStatsManager.instance.dmg;
        speedBullet = PlayerStatsManager.instance.bulletspeed;
    }
}
