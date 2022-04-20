using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 3.0f;

    private Rigidbody2D physicsBody = null;


    // Start is called before the first frame update
    void Start()
    {
        physicsBody = GetComponent<Rigidbody2D>();

        /* physicsBody.velocity = new Vector2(2, 0); */
    }

    // Update is called once per frame
    void Update()
    {
        // Ask Unity's input manager for current Horizontal / Vertical axis value. Between -1 and 1.
        float horiVal = Input.GetAxis("Horizontal");
        float vertVal = Input.GetAxis("Vertical");

        Vector2 newVal = new Vector2 (horiVal, vertVal);
        newVal = newVal * moveSpeed;
        /* physicsBody.velocity = newVal; */
    }

    public void BUp()
    {
        /* Debug.Log("Bup :D"); */
        Vector2 bupVal = new Vector2(0, moveSpeed);
        physicsBody.velocity = bupVal;
    }
    public void BDown()
    {
        /* Debug.Log("Bdown :("); */
        Vector2 bdownVal = new Vector2(0, -moveSpeed);
        physicsBody.velocity = bdownVal;
    }
    public void BLeft()
    {
        /* Debug.Log("Bleft :O"); */
        Vector2 bleftVal = new Vector2(-moveSpeed, 0);
        physicsBody.velocity = bleftVal;
    }
    public void BRight()
    {
        /* Debug.Log("Bright :)"); */
        Vector2 brightVal = new Vector2(moveSpeed, 0);
        physicsBody.velocity = brightVal;
    }
}
