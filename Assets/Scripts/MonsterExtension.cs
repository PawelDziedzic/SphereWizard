using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterExtension : MonoBehaviour
{
    MonsterScript papa;
    ProtoPlayerScript thePlayer;
    void OnEnable()
    {
        papa = GetComponentInParent<MonsterScript>();
    }
    

    public void GetOrbed(KeyValuePair<int, Vector3> pair)
    {
        papa.GetOrbed(pair);
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.tag=="Player")
        {
            Vector3 vel = papa.GetComponent<Rigidbody>().velocity - col.attachedRigidbody.velocity;
            col.SendMessage("receiveDamage", new AnAttack(1, vel, 0));
        }
    }
}
