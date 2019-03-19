using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour {

    Vector3 mousePos;
    Vector3 worldPos;

    public GameObject click;

    public Camera cam;

    void Start()
    {
       
       
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {

            mousePos = Input.mousePosition;
            mousePos.z = 50f;
            worldPos = cam.ScreenToWorldPoint(mousePos);
            Instantiate(click, worldPos, Quaternion.identity);
        }
    }

    


}
