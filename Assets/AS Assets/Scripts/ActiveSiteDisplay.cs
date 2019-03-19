using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSiteDisplay : MonoBehaviour
{


    public static float molNum;

    void Start()
    {
        DisplayActiveSite();
        molNum.Equals(0);
    }

    void DisplayActiveSite()
    {
        FileManager.MetaFile[] activeSite = FileManager.GetPieces("ActiveSite");
        // TODO: update for multiple Active Sites

        MolFile molFile = new MolFile(activeSite[0]);
        // TODO: be able to select other Active Sites (if available)

        Transform activeSiteTrans = CreateTransform("ActiveSite", transform);
        
        DisplayAtoms.Display(molFile.GetAtomDetailList(), activeSiteTrans);
    }

    Transform CreateTransform(string name, Transform parent, Vector3 localPosition = default(Vector3))
    {
        Transform trans = new GameObject(name).transform;
        trans.transform.parent = parent;
        trans.transform.localPosition = localPosition;

        return trans;
    }



    void OnTriggerStay(Collider molecule)
    {

        if (molecule.gameObject.tag.Equals("MOL"))
        {
            molNum.Equals(1);
        }
        else
        {
            molNum.Equals(0);
        }
    }

}
