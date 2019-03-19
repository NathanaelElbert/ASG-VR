using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        if (Input.GetKey(KeyCode.KeypadPlus))
        {
            transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);
        }
        if (Input.GetKey(KeyCode.KeypadMinus))
        {
            transform.localScale -= new Vector3(0.2f, 0.2f, 0.2f);
        }

    }
}
