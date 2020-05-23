using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class playerMovement : MonoBehaviour
{
    public float velocity = 10f;
    public Vector3 desiredVelocity { get; private set; }

    public BoolVariable isPlayerWalking;

    public Animator animator;

    private Camera cam;
    private Rigidbody rb;
    private const string walkingVar = "IsPlayerWalking";
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        desiredVelocity = GetInput();
    }

    private void FixedUpdate()
    {
        var yVel = rb.velocity.y;
        rb.velocity = new Vector3(desiredVelocity.x, yVel, desiredVelocity.z);
        
    }

    private Vector3 GetInput()
    {
        Vector2 inputVect = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        isPlayerWalking.Value = inputVect != Vector2.zero;
        animator.SetBool(walkingVar,isPlayerWalking.Value);
        var desiredVel = cam.transform.forward;
        desiredVel.y = 0;
        desiredVel = desiredVel * inputVect.y;
        var sideVel = cam.transform.right;
        sideVel.y = 0;
        desiredVel += sideVel.normalized * inputVect.x;
        desiredVel = desiredVel.normalized;
        return desiredVel * velocity;

    }
}
