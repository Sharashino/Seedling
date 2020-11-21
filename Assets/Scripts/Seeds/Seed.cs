using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item/Seeds")]
public class Seed : Item
{
    public int coinsToUnlock;
    public int minutesToGrow;
    public int growInMinutes;
    public string seedlingCuriosity;

    public override void Use()
    {
        Debug.Log("Using seed: " + itemName);
    }
}
