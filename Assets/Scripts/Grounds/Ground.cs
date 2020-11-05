using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item/Ground")]
public class Ground : Item
{
    public bool isInPot;
    public GameObject itemObject;

    public enum SoilType
    {
        Sandy,
        Clay,
        Silt,
        Peat,
        Chalk,
        Loam
    }

    public virtual void Use()
    {
        Debug.Log("Using ground: " + itemName);
    }
}
