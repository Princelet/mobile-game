using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour
{
    public bool isColliding = true;

    private void FixedUpdate()
    {
        if (isColliding)
        {
            // Stuff
        }

        isColliding = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // get thing we ran into
        GameObject otherObject = collision.gameObject;

        // get thing name
        string otherName = otherObject.name;

        // get thing tag
        string otherTag = otherObject.tag;

        // get layer (physics) of the thing
        int otherLayer = otherObject.layer;

        // check if script is attached and get
        // getting a component from other object
        SpriteRenderer spriteRenderer = otherObject.GetComponent<SpriteRenderer>();

        Debug.Log("Name: " + otherName);
        Debug.Log("Name: " + otherTag);
        Debug.Log("Name: " + otherLayer);
        if (spriteRenderer != null)
            spriteRenderer.color = Color.white;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("EEEEEEEEEEEE");
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("A");
    }
}
