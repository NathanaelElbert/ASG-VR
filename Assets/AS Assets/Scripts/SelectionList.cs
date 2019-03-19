using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
public class SelectionList : MonoBehaviour
{
	const int RENDER_QUEUE_OVERLAY = 4000;

	FileManager.MetaFile[] moleculeFiles;
	public int width = 180;
	public int height = 100;
	public int rows = 5;
	public int columns = 1;
	public int curPageNum = 1;
	public int padding = 10;
	
	void Start () {
		LoadMolecules();
		Display();
	}

	void LoadMolecules()
	{
		moleculeFiles = FileManager.GetPieces("UserPiece");
	}

	void Display()
	{
		int absMaxItemCount = Mathf.Clamp(rows, 0, moleculeFiles.Length); // For Temp Number
		for( int i = 1; i <= absMaxItemCount; i++)
		{
			GameObject preview = CreatePreviewWindow();
			PositionPreviewWindow(preview, i);
			AddMolecule(preview, i); // Temp Number
			SetLayerInChildren(preview, 8); // Layer 8 = Preview Thumbnail
		}
	}

	GameObject CreatePreviewWindow()
	{
		GameObject window = new GameObject("MoleculePreview");
		GameObject moleculeObject = new GameObject("MoleculeObject");
		RectTransform moleculeObjectRect = moleculeObject.AddComponent<RectTransform>();
        MakeDragable(window);
		moleculeObject.transform.SetParent(window.transform);
		moleculeObjectRect.localScale = Vector3.one * 5;
		window.AddComponent<RectTransform>().sizeDelta = new Vector2(width, height);
        window.AddComponent<Image>();//.sprite = GameObject.Find("Background");
		window.transform.SetParent(transform);

		return window;
	}

	void PositionPreviewWindow(GameObject window, int itemNum)
	{
		RectTransform rect = window.GetComponent<RectTransform>();
		rect.localPosition = Vector3.zero;
		rect.pivot = rect.anchorMin = rect.anchorMax = new Vector2(0.5f,1f);
		rect.localScale = Vector3.one;
		int xPos = padding + (padding + height) * (itemNum - 1);
		rect.anchoredPosition = new Vector2(0, -xPos);
	}

	void AddMolecule(GameObject window, int moleculeNum)
	{
		MolFile molFile = new MolFile((FileManager.MetaFile)moleculeFiles.GetValue(moleculeNum-1));
		DisplayAtoms.Display( molFile.GetAtomDetailList(), window.transform.Find("MoleculeObject").transform );

	}

	void SetLayerInChildren(GameObject parent, int layer, int renderQueue = RENDER_QUEUE_OVERLAY)
	{
		foreach (Transform child in parent.transform.GetComponentsInChildren<Transform>())
		{
			child.gameObject.layer = layer;
			MeshRenderer meshRenderer = child.gameObject.GetComponent<MeshRenderer>();
			if( meshRenderer )
				meshRenderer.material.renderQueue = renderQueue;
		}
	}

    void MakeDragable(GameObject gameObject)
    {
        gameObject.AddComponent<DragObject>();
    }
}
*/