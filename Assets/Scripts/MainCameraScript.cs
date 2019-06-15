using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraScript : MonoBehaviour
{
    public float rotationSpeed = 100.0f;
    float rotationRate;    

    void Update()
    {
        rotationRate = rotationSpeed * Input.GetAxis("Mouse Y");
        rotationRate *= Time.deltaTime;
        transform.RotateAround(ProtoPlayerScript.instance.orbPoint, transform.right, -rotationRate);
    }
}
