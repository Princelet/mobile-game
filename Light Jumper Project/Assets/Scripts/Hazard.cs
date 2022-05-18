using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Purpose:
// This script will kill the player when they touch the object this script is attached to

public class Hazard : MonoBehaviour
{
    [Header("However much damage is dealt")]
    // How much damage something should deal
    public int hazardDamage;

    private void OnCollisionStay2D(Collision2D collision)
    {
        // Get health component from the object
        PlayerHealth healthScript = collision.gameObject.GetComponent<PlayerHealth>();

        // When hazard object collides with player...
        if (healthScript)
        {
            // We hit the player!
            healthScript.LoseHealth(-hazardDamage);
        }
    }
}
