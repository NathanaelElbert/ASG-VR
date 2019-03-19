using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    [SerializeField] Transform rotateParent = null; // optional to rotate a different transform


    public float turnSpeed = 50f;
    Transform objectToRotate;
    [SerializeField] bool autoRotate;
    [SerializeField] float autoRotateSpeed = 0.5f;
    [SerializeField] float maxRotation = 10f;

    private bool goOn;
    private bool rotate;


    private void Start()
    {
        objectToRotate = (rotateParent == null) ? transform : rotateParent;
        rotate.Equals(autoRotate);
    }

    void Update()
    {
       


            if (Input.GetKey(KeyCode.Keypad8))
            {
                objectToRotate.Rotate(Vector3.left, -turnSpeed * Time.deltaTime);
                goOn.Equals(true);
                rotate.Equals(false);
            }


            if (Input.GetKey(KeyCode.Keypad2))
            {
                objectToRotate.Rotate(Vector3.left, turnSpeed * Time.deltaTime);
                goOn.Equals(true);
                rotate.Equals(false);
            }

            if (Input.GetKey(KeyCode.Keypad4))
            {
                objectToRotate.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
                goOn.Equals(true);
                rotate.Equals(false);
            }

            if (Input.GetKey(KeyCode.Keypad6))
            {
                objectToRotate.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
                goOn.Equals(true);
                rotate.Equals(false);
            }


        

        goOn.Equals(false);



            if (goOn.Equals(false) && autoRotate.Equals(true))
            {
                rotate = true;
            }



            if (rotate.Equals(true))
            {
                objectToRotate.transform.Rotate(Vector3.up, autoRotateSpeed * Mathf.Sin(Time.time * maxRotation), Space.Self);

            }



        










    }
}




// TODO: also add a function that rotates in mobile

// [SerializeField] bool autoRotate = true;
//[SerializeField] float autoRotateSpeed = 0.5f;
//[SerializeField] float maxRotation = 10f;

//private bool goOn;
//private bool rotate;



//Transform objectToRotate;

//void Start()
//{
//  objectToRotate = (rotateParent == null) ? transform : rotateParent;
//goOn.Equals(false);
//     rotate.Equals(autoRotate);
// }

// void Update()
// {



//   if (goOn.Equals(true))
// {
//   rotate = false;
//}

//if (goOn.Equals(false) && autoRotate.Equals(true))
//{
//  rotate = true;
//}



//if (rotate.Equals(true))
//{
//  objectToRotate.rotation = Quaternion.Euler(0f, maxRotation * Mathf.Sin(Time.time * autoRotateSpeed), 0f);

//}


//if (PlayerMoveController.go.Equals(true))
//{
//  goOn = true;
//}






//}



//}
