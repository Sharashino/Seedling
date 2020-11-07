using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Watering Can", menuName = "Inventory/Item/Watering can")]
public class WaterCan : Item
{

    public override void Use()
    {
        Debug.Log("You watered down " + itemUsedOnObject);
        itemUsedOnObject.GetComponent<Seedling>().IGotWateredDown();
    }
}
