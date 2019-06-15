using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterExtension : MonoBehaviour
{
    MonsterScript papa;
    void OnEnable()
    {
        papa = GetComponentInParent<MonsterScript>();
    }
    

    public void GetOrbed(KeyValuePair<int, Vector3> pair)
    {
        papa.GetOrbed(pair);
    }
}
