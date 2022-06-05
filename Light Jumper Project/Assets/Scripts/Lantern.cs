using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lantern : MonoBehaviour
{
    public Text LanternDisplay;
    private Animator animator = null;
    private bool isLit;

    void Start()
    {
        animator = GetComponent<Animator>();
        LanternDisplay.text = "0";
    }

    // Called when object overlaps trigger object
    // Our condition
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Interaction with flame only
        // Will be flame if it has FlameAttack script

        FlameAttack flameAttackScript = collision.gameObject.GetComponent<FlameAttack>();

        isLit = animator.GetBool("IsLit");

        // Check if it has variables
        if (collision.CompareTag("Flame"))
        {
            LanternDisplay.text = (int.Parse(LanternDisplay.text) + 1).ToString();

            animator.SetBool("IsLit", true);
        }
    }
}
