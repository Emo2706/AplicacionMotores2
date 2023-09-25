using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    public int maxLife;
   protected int _life;

    private void Start()
    {
        _life = maxLife;
    }

    public abstract void TakeDmg(int dmg);
}
