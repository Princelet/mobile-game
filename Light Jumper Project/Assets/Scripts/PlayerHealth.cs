using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public Text HealthDisplayT;
    public Image healthBarImage;

    public float startingHealth;
    private static float currentHealth;
    private bool healing;

    public float invincibleTimer;
    public float drainTimer;
    private float lastHitTime = 0;
    private float lastHealTime = 0;
    private float lastDrainTime = 0;

    // Action: Kill Player. For now, delete game object.
    public void Kill()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoseHealth(int loseAmount)
    {
        // Condition: Has it been long enough since last damaged?
        if (Time.time >= lastHitTime + invincibleTimer)
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
            healing = true;

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

        // Display health on screen
        healthBarImage.fillAmount = Mathf.Clamp(currentHealth / startingHealth, 0, 1f);

        // Change health until...!
        if (currentHealth == 0)
        {
            Kill();
            currentHealth = startingHealth;
        }
    }

    private void FixedUpdate()
    {
        healing = false;
        // Condition: Has it been long enough since last drain
        if ((Time.time >= lastDrainTime + drainTimer) && !healing)
        {
            // Set the last hit time to now
            lastDrainTime = Time.time;

            // Since it has, change health
            ChangeHealth(-1);
        }
    }

    void Awake()
    {
        // Initialising health to start before anything else can happen
        currentHealth = startingHealth; 
    }

    void Start()
    {
        // Initialising health display
        healthBarImage.fillAmount = currentHealth;
    }
}
