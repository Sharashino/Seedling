using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item/Ground")]
public class Soil : Item
{
    public bool isInPot;
    public SoilType soilType;

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
        canBePickedUp = false;
        itemObject.GetComponent<Ground>().isInPot = true;
        itemUsedOnObject.GetComponent<Pot>().PlaceGround(itemObject);
        Debug.Log("Using ground: " + soilType);
        isInPot = true;
    }
}
