using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public Transform firePoint;
    public float moveSpeed = 3.0f;
    public float jumpSpeed = 10.0f;
    private bool onGround;

    public LayerMask groundLayer;

    private Rigidbody2D physicsBody = null;
    private Animator animator = null;
    private SpriteRenderer sprite = null;

    public GameObject flamePrefab;
    public float fireTimer;
    private float lastFireTime = 0;


    // Start is called before the first frame update
    void Start()
    {
        physicsBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
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

        if (firePoint.localPosition.x > 0)
            firePoint.localPosition = new Vector3(-firePoint.localPosition.x, firePoint.localPosition.y, firePoint.localPosition.z);

        sprite.flipX = false;
    }
    public void BRight()
    {
        float vertVal = Input.GetAxis("Vertical");
        Vector2 brightVal = new Vector2(moveSpeed, vertVal);
        physicsBody.velocity = brightVal;

        if (firePoint.localPosition.x < 0)
            firePoint.localPosition = new Vector3(-firePoint.localPosition.x, firePoint.localPosition.y, firePoint.localPosition.z);

        sprite.flipX = true;
    }
    public void BFire()
    {
        // Condition: Has it been long enough since last fired?
        if (Time.time >= lastFireTime + fireTimer)
        {
            // Set the last hit time to now
            lastFireTime = Time.time;
            fireTimer = 1;
            Instantiate(flamePrefab, firePoint.position, firePoint.rotation);
        }
    }
}
