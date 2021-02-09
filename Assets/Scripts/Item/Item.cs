﻿using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public Sprite itemIcon;
    public string itemName = "New item";
    public string itemDesc = "Item description";
    public GameObject itemObject;
}