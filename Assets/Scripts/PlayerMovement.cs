using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Animator anim;
    private Rigidbody rb;
    private Vector3 playermovement;

    public float turnspeed;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        bool walking = (horizontal != 0f || vertical != 0f);//true;
        
        anim.SetBool("walking", walking);
        
        playermovement.Set(horizontal, 0, vertical);
        playermovement.Normalize();

        Vector3 forwardRotation = Vector3.RotateTowards(transform.forward, playermovement, turnspeed * Time.deltaTime, 0);
        Quaternion rotation = Quaternion.LookRotation(forwardRotation);
        rb.MoveRotation(rotation);
    }

    private void OnAnimatorMove()
    {
        rb.MovePosition(rb.position + playermovement * anim.deltaPosition.magnitude);
    }
}
