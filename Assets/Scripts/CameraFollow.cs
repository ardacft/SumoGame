using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Description: Camera follows the target. It does not rotate, look towards the z-axis.

    public Transform target; // This will hold the position of the target, that is the player character.
    public Vector3 offset;  // Distance between the camera and the target


    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = target.position + offset;
    }
}
