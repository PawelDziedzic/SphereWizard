using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour
{
    ChasePlayerScript chaseScript;
    SwingPawsScript swingPaws;
    IdlePaws idle1, idle2;
    Rigidbody myRB;

    public GameObject paw1, paw2;

    public int healthPoints;
    
    void OnEnable()
    {
        myRB = GetComponent<Rigidbody>();

        chaseScript = GetComponent<ChasePlayerScript>();
        chaseScript.enabled = true;


        idle1 = paw1.GetComponent<IdlePaws>();
        idle1.enabled = true;

        idle2 = paw2.GetComponent<IdlePaws>();
        idle2.enabled = true;
    }

    public void beginChase()
    {

        paw1.transform.Translate(transform.forward * -2);
        chaseScript.enabled = true;
        idle2.enabled = true;
        idle1.enabled = true;
    }

    public void attack()
    {
        paw1.transform.Translate(transform.forward*2);
        chaseScript.enabled = false;
        idle1.enabled = false;
        idle2.enabled = false;
    }

    public void GetOrbed(KeyValuePair<int,Vector3> pair)
    {
        Debug.Log("I was orbed!");
        --healthPoints;
        myRB.AddForce(pair.Value/10, ForceMode.Impulse);

        if(healthPoints<=0)
        {
            RemoveSelf();
        }
    }

    protected void RemoveSelf()
    {
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "Player")
        {
            Vector3 vel = myRB.velocity - col.collider.attachedRigidbody.velocity;
            col.collider.SendMessage("receiveDamage", new AnAttack(1, vel, 0));
        }
    }
}
