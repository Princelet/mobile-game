using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePickup : MonoBehaviour
{
    public int pickupVal = 10;

    // Called when object overlaps trigger object
    // Our condition
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Interaction with player only
        // Will be player if they have ScoreTotal script

        ScoreTotal scoreTotalScript = collision.GetComponent<ScoreTotal>();

        // Check if it has variable
        if (scoreTotalScript != null)
        {
            // The object has the script, and thus is the player
            // We should add to score!
            scoreTotalScript.addScore(pickupVal);

            Destroy(gameObject);
        }
    }
}
