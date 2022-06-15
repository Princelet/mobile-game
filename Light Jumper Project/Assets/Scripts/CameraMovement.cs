using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    protected Transform trackingTarget;
    private string levelName;

    void Start()
    {
        levelName = SceneManager.GetActiveScene().name;
    }
    // Update is called once per frame
    void Update()
    {
        if (levelName == "Level_3")
        {
            transform.position = new Vector3(trackingTarget.position.x, Mathf.Clamp(trackingTarget.position.y, -25, 25), -10);
        }
        else if (levelName == "Level_6")
        {
            transform.position = new Vector3(trackingTarget.position.x, Mathf.Clamp(trackingTarget.position.y, -0, 50), -10);
        }
        else
        transform.position = new Vector3(trackingTarget.position.x, Mathf.Clamp(trackingTarget.position.y, 0, 25), -10);
    }
}
