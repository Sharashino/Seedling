using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemPickUp : MonoBehaviour
{
    public Item item;

    public void PickUp(Item pickedUpItem)
    {
        if(item.canBePickedUp)
        {
            Debug.Log("Picking up: " + pickedUpItem.itemName);
            bool wasPickedUp = Inventory.instance.AddItem(pickedUpItem);
            if (wasPickedUp)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
