using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMol : MonoBehaviour {

    public float turnSpeed = 50f;
    public float moveSpeed = 25f;

    


 void Start()
    {
        
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.X))
        {
            var x = Time.deltaTime * moveSpeed;

            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Rotate(x, 0, 0);
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Rotate(-x, 0, 0);
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(-x, 0, 0, Space.World);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(x, 0, 0, Space.World);
            }

        }

        if (Input.GetKey(KeyCode.C))
        {
            var y = Time.deltaTime * moveSpeed;


            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(0, y, 0, Space.World);
                Debug.Log("UPY");
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(0, -y, 0, Space.World);
                Debug.Log("DownY");
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(0, y, 0);
                Debug.Log("RotateY");
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(0, -y, 0);
            }

        }

        if (Input.GetKey(KeyCode.Z))
        {
            var z = Time.deltaTime * moveSpeed;

            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Rotate(0, 0, -z);
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Rotate(0, 0, z);
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(0, 0, z, Space.World);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(0, 0, -z, Space.World);
            }

        }

    }
    
}
