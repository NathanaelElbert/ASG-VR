
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O : MonoBehaviour {

    Vector3 worldPos;
    bool ist;


    public GameObject mol;
     GameObject newmol;
    public GameObject Instan;
    public Transform istParent;



    // Use this for initialization
    void Start()
    {
        worldPos = new Vector3(-30, 70, -15);
        newmol.transform.parent = istParent;


    }

    // Update is called once per frame
    void Update()
    {
        if (ist.Equals(false))
        {
            newmol = Instantiate(mol, worldPos, Quaternion.identity, istParent);

            Instan.GetComponent<C>().enabled = false;
            ist.Equals(true);
        }
    }
}
