using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// Can only be attached to a game object with a button component on it
[RequireComponent(typeof(Button))]

// Additional items allow responses to mouse/touch events
public class HeldButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    // Store button
    private Button button;

    // Tracks whether button is pressed
    private bool pressed = false;

    // Function is called when user first clicks button
    public void OnPointerDown(PointerEventData eventData)
    {
        // Button might be disabled! Check it
        if (!button.interactable)
            return;

        // When pointer is down on the button it is pressed
            pressed = true;
       
    }

    // Function is called when user stops clicking button
    public void OnPointerUp(PointerEventData eventData)
    {
        // When pointer is up off the button it is no longer pressed
        pressed = false;
    }

    // Function is called when user moves off button
    public void OnPointerExit(PointerEventData eventData)
    {
        // When pointer is moved off the button it is no longer pressed
        pressed = false;
    }

    // Awake is called before anything else on the script
    void Awake()
    {
        button = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        // If the button has been recorded as a current press...
        if (pressed)
        {
            // If not null, call onClick function set up in Unity
            button.onClick?.Invoke();
        }
    }
}
