using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaPlayerScript : MonoBehaviour
{
    Rigidbody myRB;
    bool willJump = false, willMove = false, willStrafe = false, willThrow = false, willCatch = false, willTurn = false;
    bool isGrounded = false;
    public static AlphaPlayerScript instance;
    private Animator myAni;

    public Vector3 hitBoxCenter;
    public float hitBoxRadius;

    RaycastHit groundHit;
    protected float groundHitHeight;
    protected float castRadius;
    public float fallRate;
    public float jumpStrength;

    private Vector3 proxyPosition;
    protected Vector3 movementVector;

    public float rotationSpeed = 100.0f;
    float rotationRate;

    public float movementspeed = 50.0f;
    float movementRate;

    public float strafespeed = 50.0f;
    float strafeRate;

    void OnEnable()
    {
        instance = this;
        myRB = GetComponent<Rigidbody>();
        myAni = GetComponent<Animator>();
        groundHitHeight = 0.5f;
        castRadius = 0.5f;
    }

    void Update()
    {
        ClearRequests();

        //jump request DONE
        RequestJump();
        //shot request DONE
        RequestShot();
        //shot execution

        //move request DONE
        RequestMovement();
        //strafe request DONE
        RequestStrafe();
        //Turn request DONE
        RequestTurn();

        //turn execution DONE
        ApplyRotation();

        //jump execution WIP
        if (isGrounded)
            ExecuteJump();

        //catch execution
    }

    void ClearRequests()
    {
        willMove = false;
        willStrafe = false;
        willThrow = false;
        willTurn = false;
        willJump = false;
        willCatch = false;
    }

    void RequestShot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            willThrow = true;
        }
    }

    void RequestJump()
    {
        if (Input.GetButtonDown("Space"))
        {
            willJump = true;
        }
    }

    void RequestMovement()
    {
        movementRate = Input.GetAxis("Vertical");
        if (movementRate != 0)
        {
            movementRate *= Time.deltaTime;
            willMove = true;
        }
    }

    void RequestStrafe()
    {
        strafeRate = Input.GetAxis("Horizontal");
        if (strafeRate != 0)
        {
            strafeRate *= Time.deltaTime;
            willStrafe = true;
        }
    }

    void RequestTurn()
    {
        rotationRate = Input.GetAxis("Mouse X");
        if(rotationRate!=0)
        {
            rotationRate *= Time.deltaTime * rotationSpeed;
            willTurn = true;
        }
    }

    void FixedUpdate()
    {
        //grounded check DONE
        CheckForGround();
        //apply gravity(cond) DONE
        if (!isGrounded)
            ApplyGravity();


        //move execution
        if (willMove || willStrafe)
        {
            ApplyMovement();
        }

        //apply inertia
    }

    void CheckForGround()
    {
        if(Physics.SphereCast(transform.position,castRadius,Vector3.down,out groundHit, groundHitHeight))
        {
            isGrounded = true;
            proxyPosition = transform.position;
            proxyPosition[1] = groundHit.point[1] + 1f;
            transform.position = proxyPosition;
        }
        else
        {
            isGrounded = false;
        }
    }
    

    void ApplyGravity()
    {
        myRB.AddForce(new Vector3(0f, -1f * fallRate, 0f), ForceMode.Acceleration);
    }

    void ApplyMovement()
    {
        movementVector = (transform.right * strafeRate + transform.forward * movementRate).normalized * movementspeed;
        myRB.AddForce(movementVector, ForceMode.Acceleration);
    }

    void ApplyRotation()
    {
        transform.Rotate(0, rotationRate, 0);
    }

    void ExecuteJump()
    {
        if(willJump)
        {
            willJump = false;
            myRB.AddForce(new Vector3(0f, jumpStrength, 0.2f * jumpStrength), ForceMode.VelocityChange);
            //JUMP
        }
    }
}
