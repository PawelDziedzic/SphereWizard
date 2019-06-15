using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectionScript : MonoBehaviour
{
    MonsterScript chaseParent;

    void OnEnable()
    {
        chaseParent = transform.parent.GetComponent<MonsterScript>();
    }

    void OnTriggerEnter()
    {
        chaseParent.attack();
    }

    void OnTriggerExit()
    {
        chaseParent.beginChase();
    }
}
