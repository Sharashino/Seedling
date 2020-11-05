using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item/Ground")]
public class Ground : Item
{
    public bool isInPot;
    public GameObject Pot;
    
    public enum SoilType
    {
        Sandy,
        Clay,
        Silt,
        Peat,
        Chalk,
        Loam
    }
    public override void Use()
    {
        Pot = itemUsedOnObject;
        Pot.GetComponent<Pot>().PlaceGround(itemObject);
        Debug.Log("Using ground: " + itemName);
    }
}
