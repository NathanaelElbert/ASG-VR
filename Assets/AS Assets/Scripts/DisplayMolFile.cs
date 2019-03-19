
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DisplayAtoms
{
    public static void Display(List<AtomDetail> atomDetail, Transform parent)
    {
        int count = 0;
        GameObject dispAtom;
        Vector3 centerPoint = Vector3.zero;
                
        //Rigidbody rb = parent.gameObject.AddComponent<Rigidbody>();
        //rb.AddForce(Random.insideUnitCircle * 3, ForceMode.VelocityChange);
        //rb.useGravity = false;

        foreach (AtomDetail atom in atomDetail)
        {
            dispAtom = GameObject.CreatePrimitive(PrimitiveType.Cube);
            dispAtom.name = atom.atomSymbol + " " + (++count);
            dispAtom.transform.parent = parent;

            //Rigidbody rb = dispAtom.AddComponent<Rigidbody>();
            //rb.AddForce(Random.insideUnitCircle * 3, ForceMode.VelocityChange);

            BoxCollider coll = dispAtom.GetComponent<BoxCollider>();
            coll.isTrigger = false;
            coll.size *= 1; 

            dispAtom.transform.localPosition = atom.position;

            if (atom.atomSymbol == "H")
                dispAtom.transform.localScale = Vector3.one * 1f;
            else
                dispAtom.transform.localScale = Vector3.one * 3f;


            Renderer rend = dispAtom.GetComponent<Renderer>();
            rend.material = new Material(Shader.Find("Standard"));
            rend.material.color = GetAtomColor(atom.atomSymbol);

            // Get the sum of all the Positions of the atoms
            centerPoint += dispAtom.transform.localPosition;
            
            //if (atom.bond != null)
               // foreach (int bond in atom.bond)
                   // CreateBond(atom.position, atomDetail[bond].position, parent, 0.25f);
        }

        if (count > 0)
            centerPoint /= count;

        // Change the offset of the parent to center the molecule 
        parent.transform.localPosition -= centerPoint;
    }

    //static void CreateBond(Vector3 start, Vector3 end, Transform parent, float thickness = 0.33f)
    //{
       // GameObject dispBond = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
       // GameObject bondHolder = new GameObject();
       // GameObject tempPos = new GameObject();

        //bondHolder.name = "Bond";
       // bondHolder.transform.parent = parent;
       // dispBond.transform.parent = bondHolder.transform;
       // tempPos.transform.parent = parent;

       // dispBond.transform.Rotate(Vector3.right, 90f);
       // dispBond.transform.localScale = new Vector3(thickness,  // TODO: Make this a user option
                                             //       0.5f,
                                             //       thickness);

      //  dispBond.transform.localPosition = new Vector3(0f, 0f, dispBond.transform.localScale.y);

      //  bondHolder.transform.localPosition = start;
      //  tempPos.transform.localPosition = end;

       // bondHolder.transform.localScale = new Vector3(1f, 1f, Vector3.Distance(start, end));

       // bondHolder.transform.LookAt(tempPos.transform);
      //  ScriptableObject.Destroy(tempPos);
    //}

    static Color GetAtomColor(string symbol)
    {
        Color color = Color.magenta;

        switch (symbol)
        {
            case "H":
                color = Color.white;
                break;
            case "C":
                color = Color.black;
                break;
            case "N":
                color = new Color32(0x22, 0x33, 0xff, 0xff); // Dark Blue
                break;
            case "O":
                color = Color.red;
                break;
            case "F":
            case "Cl":
                color = Color.green;
                break;
            case "Br":
                color = new Color32(0x99, 0x22, 0x00, 0xff); // Dark Red
                break;
            case "I":
                color = new Color32(0x66, 0x00, 0xbb, 0xff); // Dark Violet
                break;
            case "He":
            case "Ne":
            case "Ar":
            case "Xe":
            case "Kr":
                color = Color.cyan;
                break;
            case "P":
                color = new Color32(0xff, 0x99, 0x00, 0xff); // Orange
                break;
            case "B":
                color = new Color32(0xff, 0xaa, 0x77, 0xff); // Salmon
                break;
            case "Li":
            case "Na":
            case "K":
            case "Rb":
            case "Cs":
            case "Fr":
                color = new Color32(0x77, 0x00, 0xff, 0xff); // Violet
                break;
            case "Be":
            case "Mg":
            case "Ca":
            case "Sr":
            case "Ba":
            case "Ra":
                color = new Color32(0x00, 0x77, 0x00, 0xff); // Dark Green
                break;
            case "Ti":
                color = Color.gray;
                break;
            case "Fe":
                color = new Color32(0xdd, 0x77, 0x00, 0xff); // Dark Orange
                break;
            default:
                color = new Color32(0xdd, 0x77, 0xff, 0xff); // Pink
                break;
        }

        return color;
    }
}
