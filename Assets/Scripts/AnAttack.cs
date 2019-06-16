using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnAttack
{
   public   Vector3 velocity;
    public int damage;
    public int type;

    public AnAttack(int d,Vector3 v,int t)
    {
        damage = d;
        velocity = v;
        type = t;
    }

}