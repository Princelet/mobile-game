using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    public float jumpSpeed = 10.0f;
    private bool onGround;

    public LayerMask groundLayer;

    private Rigidbody2D physicsBody = null;
    private Animator animator = null;

    // Start is called before the first frame update
    void Start()
    {
        physicsBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        onGround = false;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        // Checks if the colliding object's layer is the ground layer mask
        if (groundLayer == (groundLayer | (1 << collision.gameObject.layer)))
        {
            onGround = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        // Ask Unity's input manager for current Horizontal / Vertical axis value. Between -1 and 1.
        float horiVal = Input.GetAxis("Horizontal");
        float vertVal = Input.GetAxis("Vertical");

        Vector2 newVal = new Vector2 (horiVal, vertVal);
        newVal = newVal * moveSpeed;

        Vector2 currentVelocity = physicsBody.velocity;
        animator.SetFloat("Vertical", currentVelocity.y);
        animator.SetFloat("Horizontal", currentVelocity.x);

        animator.SetBool("InAir", !onGround);
    }

    public void BUp()
    {
        if (onGround)
        {
            float horiVal = Input.GetAxis("Horizontal");
            Vector2 bupVal = new Vector2(horiVal, jumpSpeed);
            physicsBody.velocity = bupVal;
        }
    }
    public void BLeft()
    {
        float vertVal = Input.GetAxis("Vertical");
        Vector2 bleftVal = new Vector2(-moveSpeed, vertVal);
        physicsBody.velocity = bleftVal;
    }
    public void BRight()
    {
        float vertVal = Input.GetAxis("Vertical");
        Vector2 brightVal = new Vector2(moveSpeed, vertVal);
        physicsBody.velocity = brightVal;
    }
}
