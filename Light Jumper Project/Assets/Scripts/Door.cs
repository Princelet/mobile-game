using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public string targetScene;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check it's the player that collided
        if (collision.CompareTag("Player"))
        {
            // It's the player
            // Action time - Change scene
            SceneManager.LoadScene(targetScene);
        }
    }
}
