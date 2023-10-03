using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour, I_Damagable
{
    public int maxLife;
   [HideInInspector]public float life;
    protected bool _isDead;

    protected virtual void Start()
    {
        life = maxLife;
    }

    public virtual void DamageTaken(float DMGreceived)
    {
        life -= DMGreceived;
        if (life <= 0)
        {
            _isDead = true;
        }
        else _isDead = false;


    }
}
