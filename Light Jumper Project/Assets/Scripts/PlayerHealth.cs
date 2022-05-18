using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Text HealthDisplayT;

    public int startingHealth;
    private int currentHealth;

    public float invincibleTime;
    private float lastHitTime = 0;
    private float lastHealTime = 0;


    // Action: Kill Player. For now, delete game object.
    public void Kill()
    {
        // Destroy object this script is connected to
        Destroy(gameObject);
    }

    public void LoseHealth(int loseAmount)
    {
        // Condition: Has it been long enough since last damaged?
        if (Time.time >= lastHitTime + invincibleTime)
        {
            // Set the last hit time to now
            lastHitTime = Time.time;

            // Since it has, change health
            ChangeHealth(loseAmount);
        }
    }
    public void GainHealth(int gainAmount)
    {
        // Condition: Has it been long enough since last healed?
        if (Time.time >= lastHealTime + 0.1)
        {
            // Set the last heal time to now
            lastHealTime = Time.time;

            // Since it has, change health
            ChangeHealth(gainAmount);
        }
    }

    public void ChangeHealth(int changeAmount)
    {
        currentHealth += changeAmount;

        // Action: Clamp health between 0 and starting health
        // Prevents going negative or too high!
        currentHealth = Mathf.Clamp(currentHealth, 0, startingHealth);

        // Display health on screen (Text for now, will become a bar in the future)
        HealthDisplayT.text = currentHealth.ToString();

        // Change health until...!
        if (currentHealth == 0)
            Kill();
    }


    void Awake()
    {
        // Initialising health to start before anything else can happen
        currentHealth = startingHealth;
    }

    void Start()
    {
        // Initialising health display
        HealthDisplayT.text = currentHealth.ToString();
    }
}
