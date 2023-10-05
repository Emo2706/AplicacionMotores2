using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class SaveData
{
    public int coins;
    public int maxlife = PlayerStatsManager.instance.maxlife;
    public float speed = PlayerStatsManager.instance.speed;
    public float dmg = PlayerStatsManager.instance.dmg;
    public float shootrate = PlayerStatsManager.instance.shootrate;
    public float bulletspeed = PlayerStatsManager.instance.bulletspeed;
    public float dashcooldown = PlayerStatsManager.instance.dashcooldown;
}
