using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseOrbScript : MonoBehaviour
{
    public int nature;//0 - fire, 1 - lightning, 10 - nothing

    protected void RemoveSelf()
    {
        Destroy(gameObject);
    }
}
