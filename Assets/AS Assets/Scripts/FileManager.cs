using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEditor;

public static class FileManager
{
    public struct MetaFile
    {
        public string Name;
        public string Compound;
        public TextAsset MolData;
    }

	public static MetaFile[] GetPieces(string folder)
    {
        TextAsset[] textAssets = Resources.LoadAll<TextAsset>(folder);

        //string[] assetList = AssetDatabase.FindAssets("",new string[] {"Assets/Resources/" + folder});
        MetaFile[] meta = new MetaFile[textAssets.Length];
        
        for ( int i = 0; i < textAssets.Length; ++i)
        {
            meta[i] = GetPiecesMeta(textAssets[i]);
        }

        return meta;
    }

    static MetaFile GetPiecesMeta(TextAsset textAsset)
    {
        MetaFile meta = new MetaFile();
        string matchPattern = "(?<Compound>[A-z0-9]*)_(?<Name>[A-z0-9]*)";
        Match match = Regex.Match(textAsset.text, matchPattern);

        // Get name and add space(s) in camelcased name
        meta.Name = Regex.Replace(match.Groups["Name"].Value, "(\\B[A-Z])", " $1");
        meta.Compound = match.Groups["Compound"].Value;
        meta.MolData = textAsset;

        return meta;
    }
}
