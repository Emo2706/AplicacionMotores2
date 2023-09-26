using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashCommand :CommandInputs
{
    public override void Execute(Ship ship)
    {
        ship.ActivateDash();
    }

   
}
