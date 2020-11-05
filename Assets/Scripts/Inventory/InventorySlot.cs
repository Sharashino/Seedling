using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Item item;
    public Image itemIcon;
    
    //Adding new item
    public void AddItem(Item newItem)
    {
        item = newItem;
        itemIcon.sprite = item.itemIcon;
        itemIcon.enabled = true;
    }

    //Pressing on item to use it 
    public void UseItemOn(GameObject itemUsedOn, GameObject usedItem)
    {
        if (item != null)
        {
            item.itemObject = usedItem;
            item.itemUsedOnObject = itemUsedOn;
            item.Use();
            ClearSlot();
        }
    }

    //Pressing on item to use it 
    public void UseItem()
    {
        if(item != null)
        {
            item.Use();
            ClearSlot();
        }
    }

    //Clearing item slot
    public void ClearSlot()
    {
        item = null;
        itemIcon.sprite = null;
        itemIcon.enabled = false;
    }

    //Pressing remove button on item
    public void RemoveItem()
    {
        Inventory.instance.Remove(item);
    }
}
