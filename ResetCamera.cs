using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetCamera : MonoBehaviour
{
    private Vector3 originalPosition;
    private Quaternion originalRotation;

    void Awake()
    {
        this.originalPosition = this.transform.position;
        this.originalRotation = this.transform.rotation;
    }

    //Call this function to reset object's position and rotation
    public void resetTransform()
    {
        this.transform.position = this.originalPosition;
        this.transform.rotation = this.originalRotation;
    }
}
