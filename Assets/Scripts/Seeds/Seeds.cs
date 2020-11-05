using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item/Seeds")]
public class Seeds : Item
{
    public GameObject seedsItem;
    public override void Use()
    {
        Debug.Log("Using seed: " + itemName);
        seedsItem.GetComponent<Seedling>().PlantASeedling(itemUsedOnObject);
    }
}
