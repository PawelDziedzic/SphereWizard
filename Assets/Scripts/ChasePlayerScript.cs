using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayerScript : MonoBehaviour
{
    public float chaseSpeed;

    Vector3 movementVector;

    void OnEnable()
    {
        chaseSpeed = 0.1f;
    }

    void Update()
    {
        movementVector = (ProtoPlayerScript.instance.transform.position - transform.position).normalized;
        transform.forward = movementVector;
        transform.Translate(movementVector * chaseSpeed, Space.World);
    }
}
