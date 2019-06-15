using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtoPlayerScript : MonoBehaviour
{
    Rigidbody myRB;
    RaycastHit hitInfo;
    public Vector3 orbPoint;
    public static ProtoPlayerScript instance;

    public float rotationSpeed = 100.0f;
    float rotationRate;

    public float movementspeed = 50.0f;
    float movementRate;

    public float strafespeed = 50.0f;
    float strafeRate;

    public float fallRate = 0.5f;
    public int HP = 10;

    private Vector3 movementVector;

    protected int natureOfOrb;//0 - fire, 1 - lightning, 10 - nothing
    protected GameObject stationaryOrb;
    protected GameObject shotOrb;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        myRB = GetComponent<Rigidbody>();
        natureOfOrb = 10;
        orbPoint = new Vector3(transform.GetChild(0).transform.position.x,
                                transform.position.y,
                                transform.GetChild(0).transform.position.z);
        Debug.Log(transform.GetChild(0).transform.name);
    }

    void Update()
    {
        myRB.velocity = Vector3.zero;
        orbPoint = transform.GetChild(0).transform.position - transform.GetChild(0).transform.forward *
            (transform.GetChild(0).transform.localPosition.z+0.5f);
        Debug.DrawRay(orbPoint, transform.GetChild(0).transform.forward * 20f, Color.white);
        if (Input.GetButtonDown("Fire1"))
        {
            if (natureOfOrb == 10)
            {
                if (Physics.Raycast(orbPoint, transform.GetChild(0).transform.forward, out hitInfo, 20f))
                {
                    if(hitInfo.transform.tag == "receiver")
                        hitInfo.transform.SendMessage("Send");
                }
            }
            else
            {
                Throw();
            }
        }

        
        movementRate = Input.GetAxis("Vertical");
        movementRate *= Time.deltaTime;

        strafeRate = Input.GetAxis("Horizontal");
        strafeRate *= Time.deltaTime;

        rotationRate = rotationSpeed * Input.GetAxis("Mouse X");
        rotationRate *= Time.deltaTime;

        movementVector = (transform.right*strafeRate + transform.forward*movementRate).normalized*movementspeed;

        //transform.Translate(strafeRate, 0, movementRate);
        myRB.AddForce(movementVector, ForceMode.VelocityChange);
        transform.Rotate(0, rotationRate, 0);
    }

    void FixedUpdate()
    {
        myRB.AddForce(new Vector3(0f, -1f*fallRate, 0f), ForceMode.VelocityChange);
    }

    void Throw()
    {
        stationaryOrb.SendMessage("RemoveSelf");
        if (natureOfOrb == 0)
            shotOrb = Instantiate(OrbManagerScript.getPlayerShotF(), orbPoint, Quaternion.identity);
        else
            shotOrb = Instantiate(OrbManagerScript.getPlayerShotL(), orbPoint, Quaternion.identity);
        shotOrb.transform.forward = transform.forward;
        shotOrb.SendMessage("Fly");
        natureOfOrb = 10;
    }

    void Catch(int nature)
    {
        if (natureOfOrb == 10)
        {
            natureOfOrb = nature;
            if (natureOfOrb == 0)
                stationaryOrb = Instantiate(OrbManagerScript.getPlayerHeldF(), orbPoint, Quaternion.identity);
            else
                stationaryOrb = Instantiate(OrbManagerScript.getPlayerHeldL(), orbPoint, Quaternion.identity);
            stationaryOrb.transform.parent = transform.GetChild(0).transform;
        }
    }

    void receiveDamage(int dmg)
    {
        HP -= dmg;
        if (HP <= 0)
            Destroy(gameObject);
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.collider.tag=="hazard")
        {
            --HP;
            Debug.Log("Hazard, on!");
            if (HP <= 0)
                GameOver();

        }
    }

    void GameOver()
    {
        Destroy(gameObject);
    }
}
