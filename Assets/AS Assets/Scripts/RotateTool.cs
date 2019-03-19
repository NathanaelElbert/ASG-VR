using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTool : MonoBehaviour
{
    public Material material;
    private bool mouseInside = false;
    private bool mouseDraging = false;
    Transform trans;

    private Color origColor;

    void OnEnable()
    {
        
        material = GetComponent<MeshRenderer>().material;
        trans = GameObject.Find("BasePoint").transform;
        //material.renderQueue = 4000; // Not working with one camera
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseEnter()
    {
        mouseInside = true;
        if (!mouseDraging)
        {
            origColor = material.color;
            material.color = new Color(origColor.r, origColor.g, origColor.b, 0.75f);
        }
    }

    private void OnMouseExit()
    {
        if (!mouseDraging)
            ResetColor();

        mouseInside = false;
    }

    private void OnMouseUp()
    {
        if (!mouseInside)
            ResetColor();
        mouseDraging = false;

    }

    private void OnMouseDrag()
    {
        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        //Vector2 mouseDeltaSpeed = new Vector2(Input.acceleration.x * mouseDelta.x, Input.acceleration.y * mouseDelta.y);

        if (!mouseDraging  )
        {
            mouseDraging = true;
        }

        trans.rotation = Quaternion.Euler(mouseDelta.y * mouseDelta.magnitude, -mouseDelta.x * mouseDelta.magnitude, 0) * trans.rotation;
    }

    void ResetColor()
    {
        material.color = origColor;
    }
}
