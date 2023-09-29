using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsManager : MonoBehaviour
{
    public static PlayerStatsManager instance;
    public int maxlife;
    public float speed;
    public float dmg;
    public float shootrate;
    public float bulletspeed;
    public float dashcooldown;


    private void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        Shop.instance.CompraItem += ImproveStat;
    }
    void Start()
    {
      
    }

    public void ImproveStat(int ID)
    {
        if (ID == EstadisticasId.MaxLife)
        {
            maxlife++;
            Debug.Log("tu vida actual es de " + maxlife);
        }
        if (ID == EstadisticasId.Damage)
        {
            dmg *= 2;
        }
        if (ID == EstadisticasId.Speed)
        {
            speed += speed * 0.2f;
        }
        if (ID == EstadisticasId.Shootrate)
        {
            shootrate += shootrate * 0.15f;
        }
        if (ID == EstadisticasId.BulletSpeed)
        {
            bulletspeed += bulletspeed * 0.2f;
        }
        if (ID == EstadisticasId.Damage)
        {
            dashcooldown -= dashcooldown *0.15f;
        }
    }
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        
    }

    public static class EstadisticasId
    {
        public const int MaxLife = 0;
        public const int Damage = 1;
        public const int Speed = 2;
        public const int Shootrate = 3;
        public const int BulletSpeed = 4;
        public const int DashCoolDown = 5;
    }
}
