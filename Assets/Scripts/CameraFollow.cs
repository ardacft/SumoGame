using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Description: Camera follows the target without rotating.

    public Transform target; //this will hold the position of the target
    public Vector3 offset;



    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = target.position + offset;
    }
}
