using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingOrbScript : BaseOrbScript
{ 
    protected float stepLength;
    protected Vector3 stepVector;


    void Update()
    {
        stepLength = rangedFloat((ProtoPlayerScript.instance.transform.position - transform.position).magnitude);
        stepVector = (ProtoPlayerScript.instance.transform.position - transform.position).normalized * stepLength;
        transform.Translate(stepVector);
    }

    float rangedFloat(float f)
    {
        if (f <= 0.01)
            return 0;
        else if (f > 3)
            return 3;
        else
            return f;
    }


    void OnTriggerEnter(Collider col)
    {
        col.SendMessage("Catch", nature);
        Debug.Log("OnTriggerEnter");
        Destroy(gameObject);
    }

}
