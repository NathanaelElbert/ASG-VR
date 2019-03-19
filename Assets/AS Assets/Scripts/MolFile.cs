using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text.RegularExpressions;

public class MolFile
{
    const string FILE_VERSION = "V2000";
    const string FILE_VERSION_V3 = "V3000";
    uint _numOfAtoms;
    uint _numOfBonds;
    string _fileVersion;
    List<AtomDetail> _atomDetailList;
    StringReader _fileString;

    public MolFile(string fullFilePath)
    {
        ReadFile(fullFilePath);
    }

    public MolFile(FileManager.MetaFile file)
    {
        ReadTextAsset(file.MolData);
    }

    public List<AtomDetail> GetAtomDetailList()
    {
        return _atomDetailList;
    }

    public void ReadTextAsset(TextAsset textAsset)
    {
        _fileString = new StringReader(textAsset.text);
        ParseFile();
    }

    /// <summary>
    /// Read a MolFile
    /// </summary>
    /// <param name="file">Full file path to the molfile.</param>
    public void ReadFile(string fullFilePath)
    {
        if (File.Exists(fullFilePath))
        {
            _fileString = new StringReader(File.ReadAllText(fullFilePath));
            ParseFile();
        }
        else
        {
            throw new FileNotFoundException(fullFilePath);
        }
    }

    void ParseFile()
    {
        Init();
        // File Format Order: Header -> Atoms -> Bonds
        ParseHeader();
        ParseAtoms();
        ParseBonds();
    }

    void Init()
    {
        _atomDetailList = new List<AtomDetail>();
    }

    Match GetMatch(string pattern)
    {
        string line;
        Match result;

        do
        {
            if (_fileString.Peek() == -1)
                throw new EndOfStreamException();

            line = _fileString.ReadLine();
            result = Regex.Match(line, pattern);
        } while (!result.Success);

        return result;
    }

    void ParseHeader()
    {
        string header_pattern = @"^(?<Atoms>[0-9 ]{3})(?<Bonds>[0-9 ]{3})(?<AtomList>[0-9 ]{3})(?:[0-9 ]{3})(?<ChiralFlag>[0-9 ]{3})(?<NumOfStext>[0-9 ]{3})(?:[0-9 ]{3}){4}(?<AddProp>[0-9 ]{3}) (?<Version>[0-9V ]{5})$";

        Match result = GetMatch(header_pattern);

        _numOfAtoms = Convert.ToUInt32(result.Groups["Atoms"].Value);
        _numOfBonds = Convert.ToUInt32(result.Groups["Bonds"].Value);
        _fileVersion = result.Groups["Version"].Value;
    }

    void ParseAtoms()
    {
        string atom_pattern = @"^(?<x>[0-9 .-]{10})(?<y>[0-9 .-]{10})(?<z>[0-9 .-]{10}) (?<Symbol>[A-z* ]{3})(?<MassDiff>[0-9 -]{2})(?<Charge>[0-9 ]{3})(?:[0-9 .-]{3}){10}$";

        for (int i = 0; i < _numOfAtoms; i++)
        {
            Match result = GetMatch(atom_pattern);
            AtomDetail atomDetail = new AtomDetail();
            atomDetail.atomSymbol = result.Groups["Symbol"].Value.Trim();
            atomDetail.position = new Vector3((Convert.ToSingle(result.Groups["x"].Value) - (Convert.ToSingle(result.Groups["x"].Value) % 3)) + 5,
                                              (Convert.ToSingle(result.Groups["y"].Value) - (Convert.ToSingle(result.Groups["y"].Value) % 3)) + 5,
                                              (Convert.ToSingle(result.Groups["z"].Value) - (Convert.ToSingle(result.Groups["z"].Value) % 3)) + 5);
        atomDetail.charge = Convert.ToInt32(result.Groups["Charge"].Value);
        _atomDetailList.Add(atomDetail);
        }
    }


    
    

    void ParseBonds()
    {
        string bond_pattern = @"^(?<BondFrom>[0-9 ]{3})(?<BondTo>[0-9 ]{3})(?<BondType>[0-9 ]{3})(?:[0-9 -]{3}){4}$";

        for (int i = 0; i < _numOfBonds; i++)
        {
            // Bound Value - 1: To convert from count base to index base
            Match result = GetMatch(bond_pattern);
            int element = Convert.ToInt32(result.Groups["BondFrom"].Value) - 1;
            AtomDetail atomDetail = _atomDetailList[element];

            if (atomDetail.bond == null)
            {
                atomDetail.bond = new List<int>();
                atomDetail.bondType = new List<BondType>();
            }
            
            atomDetail.bond.Add(Convert.ToInt32(result.Groups["BondTo"].Value)-1);
            atomDetail.bondType.Add((BondType)Convert.ToUInt32(result.Groups["BondType"].Value));

            _atomDetailList.RemoveAt(element);
            _atomDetailList.Insert(element, atomDetail);
        }
    }
}
