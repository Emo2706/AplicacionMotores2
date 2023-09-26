using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour, I_Damagable
{
    public int maxLife;
   protected float _life;
    protected bool _isDead;

    private void Start()
    {
        _life = maxLife;
    }

    public virtual void DamageTaken(float DMGreceived)
    {
        _life -= DMGreceived;
        if (_life <= 0)
        {
            _isDead = true;
        }
        else _isDead = false;


    }
}
