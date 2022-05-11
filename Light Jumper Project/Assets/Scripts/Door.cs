using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public string targetScene;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        ScoreTotal scoreTotalScript = collision.GetComponent<ScoreTotal>();

        // Check it's the player that collided
        if (collision.CompareTag("Player") && (scoreTotalScript.lanterns == 3))
        {
            // It's the player
            // They have all the lanterns lit (3)
            // Action time - Change scene
            SceneManager.LoadScene(targetScene);
        }
    }
}
