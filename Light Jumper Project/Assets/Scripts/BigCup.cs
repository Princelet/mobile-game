using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BigCup : MonoBehaviour
{
    private Animator animator = null;
    public string targetScene;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check it's the player that collided
        if (collision.CompareTag("Flame"))
        {
            // The big cup has been lit!
            // Pause then change scene!
            animator.SetBool("BigLit", true);
            Invoke("Ending", 1);
        }
    }

    void Ending()
    {
        // Load the end scene!
        SceneManager.LoadScene(targetScene);
    }
}
