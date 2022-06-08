using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing : MonoBehaviour
{
    [Header("However much damage is healed")]
    // How much damage something should deal
    public int healAmount;

    private Animator animator = null;
    public bool isLit;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // Get health component from the object
        PlayerHealth healthScript = collision.gameObject.GetComponent<PlayerHealth>();
        isLit = animator.GetBool("IsLit");

        // When player is on health object
        if (healthScript)
        {
            // If it's a lantern
            if (gameObject.name.Contains("Lantern") && isLit == true)
            {
                // The lantern is lit and the player is the object!
                healthScript.GainHealth(healAmount);
            }

            // If it's a lightspot
            if (gameObject.name.Contains("LightSpot"))
            {
                // The lantern is lit and the player is the object!
                healthScript.GainHealth(healAmount);
            }
        }
    }
}
