using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    protected Transform trackingTarget;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(trackingTarget.position.x, Mathf.Clamp(trackingTarget.position.y, 0, 10), -10);
    }
}
