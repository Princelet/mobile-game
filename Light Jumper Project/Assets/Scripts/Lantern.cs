using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lantern : MonoBehaviour
{
    public int lanternVal = 1;

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
            // We should add to the lantern value.
            scoreTotalScript.addLantern(lanternVal);


            Destroy(gameObject); // Change sprite in final, destroy for now!

        }
    }
}
