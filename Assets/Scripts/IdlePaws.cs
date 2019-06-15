using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdlePaws : MonoBehaviour
{
    int offset;

    void OnEnable()
    {
        Random rnd = new Random();
        offset = Random.Range(0, 4);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.up * Mathf.Sin(5*Time.time+offset)*0.02f);
    }
}
