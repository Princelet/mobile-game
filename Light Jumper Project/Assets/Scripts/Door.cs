using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public string targetScene;
    public Text LanternDisplay;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check it's the player that collided
        if (collision.CompareTag("Player") && (LanternDisplay.text == "3"))
        {
            // It's the player
            // They have all the lanterns lit (3)
            // Action time - Change scene
            SceneManager.LoadScene(targetScene);
        }
    }
}
