using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dolley : MonoBehaviour {


    public Transform objectToRotate;
    [SerializeField] float autoRotateSpeed = 0.5f;
    [SerializeField] float maxRotation = 10f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        objectToRotate.transform.Rotate(Vector3.up, autoRotateSpeed * Mathf.Sin(Time.time * maxRotation), Space.Self);
    }
}
