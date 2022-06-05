using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lantern : MonoBehaviour
{
    public int lanternVal = 1;
    private Animator animator = null;

    void Start()
    {
        animator = GetComponent<Animator>();
    }


    // Called when object overlaps trigger object
    // Our condition
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Interaction with flame only
        // Will be flame if it has FlameAttack script and ScoreTotal script

        FlameAttack flameAttackScript = collision.GetComponent<FlameAttack>();
        ScoreTotal scoreTotalScript = collision.GetComponent<ScoreTotal>();

        // Check if it has variables
        if (flameAttackScript && scoreTotalScript)
        {
            scoreTotalScript.addLantern(lanternVal);

            animator.SetBool("IsLit", true);
        }
    }
}
