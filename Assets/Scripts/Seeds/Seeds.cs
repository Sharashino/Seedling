﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item/Seeds")]
public class Seeds : Item
{
    public override void Use()
    {
        canBePickedUp = false;
        Debug.Log("Using seed: " + itemName);
        itemObject.GetComponent<Seedling>().PlantASeedling(itemObject, itemUsedOnObject);
    }
}
