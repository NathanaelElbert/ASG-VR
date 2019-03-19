 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    // TODO: also add a function that rotates in mobile
    [SerializeField] Transform rotateParent = null; // optional to rotate a different transform
    [SerializeField] float autoRotateSpeed = 20f;

    Transform objectToRotate;

    void Start()
    {
        objectToRotate = (rotateParent == null) ? transform : rotateParent;
    }

    void Update()
    {
       
            objectToRotate.Rotate(Vector3.up * (autoRotateSpeed * Time.deltaTime));
    }

   
}