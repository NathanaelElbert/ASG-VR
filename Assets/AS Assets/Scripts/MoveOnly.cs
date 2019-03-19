using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnly : MonoBehaviour
{


    [SerializeField] Transform rotateParent = null; // optional to rotate a different transform
    public float turnSpeed = 50f;
    Transform objectToRotate;

    // Use this for initialization
    private void Start()
    {
        objectToRotate = (rotateParent == null) ? transform : rotateParent;
     
    }

    void Update()
    {



        if (Input.GetKey(KeyCode.Keypad8))
        {
            objectToRotate.Rotate(Vector3.left, -turnSpeed * Time.deltaTime);
        
        }


        if (Input.GetKey(KeyCode.Keypad2))
        {
            objectToRotate.Rotate(Vector3.left, turnSpeed * Time.deltaTime);
          
        }

        if (Input.GetKey(KeyCode.Keypad4))
        {
            objectToRotate.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
          
        }

        if (Input.GetKey(KeyCode.Keypad6))
        {
            objectToRotate.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
            
        }
    }
}
