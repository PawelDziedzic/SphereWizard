using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JerkForward : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.Translate(transform.forward * 10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
