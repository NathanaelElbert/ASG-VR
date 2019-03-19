using System.Collections.Generic;
using UnityEngine;

public enum BondType { Single = 1, Double, Triple };

public struct AtomDetail
{
    public string atomSymbol;
    public Vector3 position;
    public List<int> bond;
    public List<BondType> bondType;
    public int charge;
}