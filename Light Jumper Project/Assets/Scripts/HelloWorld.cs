using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloWorld : MonoBehaviour
{
    public string message = "Default Message";


    // Start is called before the first frame update
    void Start()
    {
        Debug.LogWarning("Wa");
        Debug.LogError(message);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Egg");
    }
}
