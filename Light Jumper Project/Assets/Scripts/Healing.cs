using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing : MonoBehaviour
{
    [Header("However much damage is healed")]
    // How much damage something should deal
    public int healAmount;

    private void OnTriggerStay2D(Collider2D collision)
    {
        // Get health component from the object
        PlayerHealth healthScript = collision.gameObject.GetComponent<PlayerHealth>();

        // When hazard object collides with player...
        if (healthScript)
        {
            // We hit the player!
            healthScript.GainHealth(healAmount);
        }
    }
}
