using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    //basic movement variables
    public float MoveSpeed = 5f;
    public bool Moving = false;

    //jump variables
    public float JumpStrength = 5f;
    public float FallStrength = 2.5f;
    public bool TryJump = false;
    //public bool Grounded = true;
    public bool CanJump = true;

    //for self reference
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start ()
    {

	}

    private void Update()
    {
        if (Input.GetButton("Horizontal"))
            Moving = true;
        else
            Moving = false;

        if (Input.GetButtonDown("Jump") && CanJump)
            TryJump = true;
    }

    void FixedUpdate ()
    {

        if (Moving)
            rb.position += new Vector2(Input.GetAxis("Horizontal"), 0) * MoveSpeed * Time.deltaTime;
        else
            rb.velocity = new Vector2(0, rb.velocity.y);

        if (TryJump)
        {
            rb.velocity += Vector2.up * JumpStrength;
            TryJump = false;
        }

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics.gravity.y * (FallStrength - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics.gravity.y * (FallStrength - 1) * Time.deltaTime;
        }

	}


}
