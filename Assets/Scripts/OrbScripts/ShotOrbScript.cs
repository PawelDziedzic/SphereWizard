using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotOrbScript : BaseOrbScript
{
    protected Rigidbody myRB;
    public float speed;
    void OnEnable()
    {
        myRB = GetComponent<Rigidbody>();
    }

    void Fly()
    {
        myRB.AddForce(ProtoPlayerScript.instance.transform.GetChild(0).transform.forward * speed, ForceMode.VelocityChange);
    }


    void OnTriggerEnter(Collider col)
    {
        Vector3 vel = myRB.velocity;
        myRB.velocity = Vector3.zero;
        Debug.Log(col.transform.name);
        if (col.tag == "receiver" || col.tag =="hazard")
            col.SendMessage("GetOrbed", new  KeyValuePair<int,Vector3>(nature,vel));
        Disperse();
        
    }

    void Disperse()
    {
        RemoveSelf();
    }
}
