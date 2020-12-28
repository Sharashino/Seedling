using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item/Seeds")]
public class Seed : Item
{
    public int coinsToUnlock;
    public int harvestCoins;
    public int minutesToGrow;
    public bool isUnlocked = false;
    public bool isDoneGrowing = false;
    public string seedlingCuriosity;
}
